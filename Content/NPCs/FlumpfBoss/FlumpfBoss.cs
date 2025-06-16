using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace BroccoliMod.Content.NPCs.FlumpfBoss
{
    public class FlumpfBoss : ModNPC
    {
        private float floatTimer = 0f;
        private int aiState = 0; // 0 = circling, 1 = charging
        private int aiTimer = 0;
        private float circleAngle = 0f;

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 2;
        }

        public override void SetDefaults()
        {
            NPC.width = 80;
            NPC.height = 80; 
            NPC.scale = 1.5f;
            NPC.damage = 40;
            NPC.defense = 10;
            NPC.lifeMax = 4000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.value = Item.buyPrice(0, 5, 0, 0);
            NPC.knockBackResist = 0f;
            NPC.aiStyle = -1; // Custom AI
            NPC.boss = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            Music = MusicID.Boss2;
        }

        public override void AI()
        {
            Player player = Main.player[NPC.target];
            if (!player.active || player.dead)
            {
                NPC.TargetClosest(false);
                if (!player.active || player.dead)
                {
                    NPC.velocity.Y -= 0.1f;
                    if (NPC.timeLeft > 10)
                        NPC.timeLeft = 10;
                    return;
                }
            }

            aiTimer++;

            switch (aiState)
            {
                case 0:
                    {
                        float circleRadius = 220f;
                        float circleSpeed = 0.015f;
                        circleAngle += circleSpeed;
                        if (circleAngle > MathHelper.TwoPi)
                            circleAngle -= MathHelper.TwoPi;

                        // Calculate circling offset and movement
                        Vector2 offset = new Vector2((float)Math.Cos(circleAngle), (float)Math.Sin(circleAngle)) * circleRadius;
                        Vector2 targetPos = player.Center + offset;
                        Vector2 moveTo = targetPos - NPC.Center;
                        float speed = 5f;
                        if (moveTo.Length() > speed)
                            moveTo = moveTo.SafeNormalize(Vector2.Zero) * speed;
                        NPC.velocity = moveTo;

                        // Make the sprite face away from the player
                        NPC.spriteDirection = (player.Center.X > NPC.Center.X) ? -1 : 1;
                        NPC.rotation = (player.Center - NPC.Center).ToRotation() + (NPC.spriteDirection == 1 ? 0f : MathHelper.Pi);

                        // Fire a projectile at intervals
                        if (aiTimer % 90 == 0 && Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            Vector2 shootDir = (player.Center - NPC.Center).SafeNormalize(Vector2.UnitX);
                            int proj = Projectile.NewProjectile(
                                NPC.GetSource_FromAI(),
                                NPC.Center,
                                shootDir * 10f,
                                ProjectileID.RuneBlast,
                                20,
                                0f,
                                Main.myPlayer
                            );
                            Main.projectile[proj].hostile = true;
                            Main.projectile[proj].friendly = false;
                        }

                        // Switch to charge state after a delay
                        if (aiTimer > 300)
                        {
                            aiState = 1;
                            aiTimer = 0;
                        }
                        break;
                    }
                case 1:
                    {
                        // On first tick, set charge velocity with random inaccuracy
                        if (aiTimer == 1)
                        {
                            Vector2 chargeDir = (player.Center - NPC.Center).SafeNormalize(Vector2.UnitX);
                            float inaccuracy = MathHelper.ToRadians(20f);
                            float randomRot = Main.rand.NextFloat(-inaccuracy, inaccuracy);
                            chargeDir = chargeDir.RotatedBy(randomRot);

                            NPC.velocity = chargeDir * 10f;
                        }

                        // Return to circling after short charge
                        if (aiTimer > 30)
                        {
                            aiState = 0;
                            aiTimer = 0;
                        }
                        break;
                    }
            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.HealingPotion;
        }

        public override void OnKill()
        {
            // Drop loot here
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.GoldCoin, 10);
        }

        public override void FindFrame(int frameHeight)
        {
            // Blink every 60 ticks (1 second), blink lasts 10 ticks
            int blinkRate = 60;
            int blinkLength = 10;
            if ((NPC.frameCounter++ % blinkRate) < blinkLength)
            {
                NPC.frame.Y = frameHeight; // Blinking frame (frame 1)
            }
            else
            {
                NPC.frame.Y = 0; // Normal frame (frame 0)
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            // Emit blood dust when taking damage
            int amount = 10; // Number of dust particles
            for (int i = 0; i < amount; i++)
            {
                int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood,
                    Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f), 100, default, 1.5f);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}