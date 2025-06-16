using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using BroccoliMod.Content.Dusts;
using Terraria.GameContent.ItemDropRules;
using BroccoliMod.Content.Items;

// Ignore how messy this is, I am bad at coding lmao
// I hate it here, but it works for now

namespace BroccoliMod.Content.NPCs.OsloBoss
{

    [AutoloadBossHead]
    public class OsloBossBody : ModNPC
    {
        private int teleportTimer = 0;
        private int iceSpikeTimer = 0;
        private bool isDespawning = false;
        private float shrinkScale = 1f;
        private int summonOsloTimer = 0;
        private int nextSummonTime = 0;
        private int timeSinceLastHitPlayer = 0;

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Zombie];
            NPCID.Sets.MPAllowedEnemies[Type] = true;
            NPCID.Sets.BossBestiaryPriority.Add(Type);
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
        }

        public override void SetDefaults()
        {
            NPC.width = 60;
            NPC.height = 80;
            NPC.damage = 30;
            NPC.defense = 12;
            NPC.lifeMax = 3000;
            NPC.boss = true;
            NPC.knockBackResist = 0f;
            NPC.value = Item.buyPrice(0, 5, 0, 0);
            NPC.aiStyle = 3;
            AIType = NPCID.AngryBones;
            AnimationType = NPCID.Zombie;
            NPC.noGravity = false;
            NPC.noTileCollide = false;
            NPC.boss = true;
            Music = MusicID.Boss1;
            NPC.npcSlots = 10f;
            NPC.HitSound = SoundID.Item48;
            NPC.DeathSound = SoundID.DD2_WyvernDeath;
        }

        public override void AI()
        {
            // Handle despawn shrinking and dust
            if (isDespawning)
            {
                shrinkScale -= 0.01f;
                if (shrinkScale < 0.05f)
                {
                    for (int d = 0; d < 30; d++)
                    {
                        Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<Snow>(),
                            Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f));
                    }
                    NPC.active = false;
                    NPC.life = 0;
                    NPC.checkDead();
                    return;
                }
                NPC.scale = shrinkScale;
                return;
            }

            // Summon Oslo minions in expert/master mode at random intervals
            if (Main.expertMode || Main.masterMode)
            {
                if (nextSummonTime == 0)
                {
                    nextSummonTime = Main.rand.Next(180, 421);
                }
                summonOsloTimer++;
                if (summonOsloTimer >= nextSummonTime)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        Vector2 spawnPos = NPC.Center + new Vector2(Main.rand.Next(-80, 81), Main.rand.Next(-40, 41));
                        NPC.NewNPC(NPC.GetSource_FromAI(), (int)spawnPos.X, (int)spawnPos.Y, ModContent.NPCType<Oslo>());
                    }
                    summonOsloTimer = 0;
                    nextSummonTime = Main.rand.Next(180, 421);
                }
            }

            // Teleport on top of the player if not hit for 10 seconds
            timeSinceLastHitPlayer++;
            if (timeSinceLastHitPlayer >= 600)
            {
                Player player = Main.player[NPC.target];
                if (player != null && player.active && !player.dead)
                {
                    NPC.position = player.Center - new Vector2(NPC.width / 2, NPC.height / 2);
                    NPC.netUpdate = true;
                    for (int d = 0; d < 30; d++)
                    {
                        Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<Snow>(),
                            Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f));
                    }
                }
                timeSinceLastHitPlayer = 0;
            }

            // Teleport to a random side of the player every 5 seconds
            teleportTimer++;
            if (teleportTimer >= 300)
            {
                TeleportNearPlayer();
                teleportTimer = 0;
            }

            // Despawn if player is dead or inactive
            Player playerCheck = Main.player[NPC.target];
            if (playerCheck == null || !playerCheck.active || playerCheck.dead)
            {
                isDespawning = true;
                NPC.velocity = Vector2.Zero;
                NPC.dontTakeDamage = true;
                return;
            }

            // Rain IceSpike projectiles when below half health
            if (NPC.life < NPC.lifeMax / 2)
            {
                iceSpikeTimer++;
                if (iceSpikeTimer >= 40)
                {
                    iceSpikeTimer = 0;
                    Vector2 spawnPos = playerCheck.Center + new Vector2(Main.rand.Next(-200, 201), -400f);
                    Vector2 velocity = new Vector2(0, 12f);

                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        Projectile.NewProjectile(
                            NPC.GetSource_FromAI(),
                            spawnPos,
                            velocity,
                            ProjectileID.IceSpike,
                            20,
                            2f,
                            Main.myPlayer
                        );
                    }
                }
            }
            else
            {
                iceSpikeTimer = 0;
            }
        }

        // Reset the "not hit" timer when the boss hits the player
        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            timeSinceLastHitPlayer = 0;
        }

        // Teleport to the opposite side of the player, with a random offset
        private void TeleportNearPlayer()
        {
            Player player = Main.player[NPC.target];
            if (!player.active || player.dead)
                return;

            bool isLeft = NPC.Center.X < player.Center.X;
            float horizontalOffset = 250f;
            float verticalOffset = -100f;

            Vector2 teleportPosition;
            if (isLeft)
                teleportPosition = player.Center + new Vector2(horizontalOffset, verticalOffset);
            else
                teleportPosition = player.Center + new Vector2(-horizontalOffset, verticalOffset);

            for (int i = 0; i < 50; i++)
            {
                Vector2 tryPos = teleportPosition + new Vector2(Main.rand.Next(-30, 31), Main.rand.Next(-30, 31));
                float distance = Vector2.Distance(tryPos, player.Center);

                if (distance > 120f && Collision.CanHitLine(tryPos, 1, 1, player.Center, 1, 1))
                {
                    NPC.position = tryPos;
                    NPC.netUpdate = true;
                    for (int d = 0; d < 30; d++)
                    {
                        Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<Snow>(),
                            Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f));
                    }
                    break;
                }
            }
        }

        // Teleport the boss off-screen and spawn dust
        private void TeleportOffScreen()
        {
            for (int d = 0; d < 30; d++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<Snow>(),
                    Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f));
            }
            NPC.position = new Vector2(NPC.position.X, -2000f);
            NPC.netUpdate = true;
        }

        // Configure loot drops for different game modes
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<OsloBag>()));

            var notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
            notExpertRule.OnSuccess(new OneFromOptionsDropRule(
                1,
                1,
                ModContent.ItemType<OsloStaff>(),
                ModContent.ItemType<Osyo>(),
                ModContent.ItemType<Osbow>()
            ));
            npcLoot.Add(notExpertRule);

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<WiiRemote>(), 100));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.Snowball, 1, 50, 201));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.IceBlock, 1, 50, 101));
        }
    }
}