using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using BroccoliMod.Content.Items;

namespace BroccoliMod.Content.NPCs
{
    public class Oslo : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // Set the number of animation frames to match the Zombie NPC
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Zombie];
        }

        public override void SetDefaults()
        {
            // Set Oslo's stats and behavior
            NPC.width = 34;
            NPC.height = 44;
            NPC.damage = 20;
            NPC.defense = 8;
            NPC.lifeMax = 120;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 60f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 3; // Fighter AI
            AIType = NPCID.AngryBones;
            AnimationType = NPCID.Zombie;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            // Only spawn in the Snow biome on the surface
            if (spawnInfo.Player.ZoneSnow && spawnInfo.Player.ZoneOverworldHeight)
            {
                return 0.2f; // 20% of normal spawn rate
            }
            return 0f;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            // 1% chance to drop the OsloSummon item
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OsloSummon>(), 100));
        }
    }
}