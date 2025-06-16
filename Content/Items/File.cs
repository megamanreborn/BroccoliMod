using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace BroccoliMod.Content.Items
{
    // Defines the File item for the mod
    public class File : ModItem
    {
        // Sets static properties for the item
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1; // Number needed to unlock for research
        }

        // Sets the default properties of the item
        public override void SetDefaults()
        {
            Item.width = 20; // Item's hitbox width
            Item.height = 20; // Item's hitbox height
            Item.maxStack = Item.CommonMaxStack; // Maximum stack size
            Item.value = Item.buyPrice(silver: 1); // Item's value in coins
        }

        // Adds the crafting recipe for the File
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("IronBar", 10); // Requires 10 iron or lead bars
            recipe.Register(); // Registers the recipe
        }
    }
}