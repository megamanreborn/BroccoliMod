using BroccoliMod.Content.NPCs.FlumpfBoss;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace BroccoliMod.Content.Items
{
    public class FlumpfSummon : ModItem
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

        // Only allow use if the boss isn't already present
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<FlumpfBoss>());
        }

        // Called when the item is used
        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                // Play roar sound and spawn the boss
                SoundEngine.PlaySound(SoundID.Roar, player.position);

                int type = ModContent.NPCType<FlumpfBoss>();

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

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Lens, 3); // Requires 3 lenses
            recipe.AddRecipeGroup("BroccoliMod:EvilFlesh", 10); // 10 is the quantity needed
            recipe.AddTile(TileID.DemonAltar); // Crafted at an Anvil
            recipe.Register(); // Registers the recipe
        }
    }
}