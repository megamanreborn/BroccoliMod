using BroccoliMod.Content.NPCs;
using BroccoliMod.Content.NPCs.OsloBoss;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace BroccoliMod.Content.Items
{
    public class OsloSummon : ModItem
    {
        // Set static properties for the boss summon item
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 3; // Number needed for research
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 12; // Sorting priority for boss spawn items
        }

        // Set the default properties of the item
        public override void SetDefaults()
        {
            Item.width = 20; // Item width
            Item.height = 20; // Item height
            Item.maxStack = 20; // Maximum stack size
            Item.value = 100; // Sell value
            Item.rare = ItemRarityID.Blue; // Rarity color
            Item.useAnimation = 30; // Animation duration
            Item.useTime = 30; // Time between uses
            Item.useStyle = ItemUseStyleID.HoldUp; // Use style (hold up)
            Item.consumable = true; // Consumed on use
        }

        // Set the research sorting group for Journey mode
        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.BossSpawners;
        }

        // Only allow use if in the Snow biome and the boss isn't already present
        public override bool CanUseItem(Player player)
        {
            bool inSnow = player.ZoneSnow;
            return inSnow && !NPC.AnyNPCs(ModContent.NPCType<OsloBossBody>());
        }

        // Called when the item is used
        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                // Play roar sound and spawn the boss
                SoundEngine.PlaySound(SoundID.Roar, player.position);

                int type = ModContent.NPCType<OsloBossBody>();

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    NPC.SpawnOnPlayer(player.whoAmI, type);
                }
                else
                {
                    NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: player.whoAmI, number2: type);
                }
            }

            return true;
        }
    }
}