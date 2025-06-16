using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using BroccoliMod.Content.Items;

namespace BroccoliMod.Content.Items
{
    public class WoodPulp : ModItem
    {
        public override void SetStaticDefaults() {
            // Set research unlock count for Journey mode duplication
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults() {
            // Set item sprite size
            Item.width = 20;
            Item.height = 20;
            // Set max stack and value
            Item.maxStack = Item.CommonMaxStack;
            Item.value = Item.buyPrice(silver: 1);
        }

        public override void AddRecipes() {
            // Recipe: 5 Wood (any) + 1 Bottled Water at a Sink (tile 106) = 1 Wood Pulp
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("Wood", 5);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddTile(106); // Sink
            recipe.Register();
        }
    }
}