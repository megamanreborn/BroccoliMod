using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using BroccoliMod.Content.Items;

namespace BroccoliMod.Content.Items
{
    // Defines the Paper item
    public class Paper : ModItem
    {
        public override void SetStaticDefaults() {
            // Number of items needed to research for duplication in Journey mode
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults() {
            // Set item size
            Item.width = 20;
            Item.height = 20;
            // Set maximum stack size
            Item.maxStack = Item.CommonMaxStack;
            // Set item value in copper coins
            Item.value = Item.buyPrice(50);
        }

        public override void AddRecipes() {
            // Recipe: 1 WoodPulp at tile 220 creates 1 Paper
            CreateRecipe()
                .AddIngredient<WoodPulp>()
                .AddTile(TileID.Solidifier)
                .Register();
        }
    }
}