using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BroccoliMod.Content.Items;

namespace BroccoliMod.Content.Items
{ 
    // Defines the CardboardSword item for the mod
    public class CardboardSword : ModItem
    {
        // Sets the default properties of the item
        public override void SetDefaults()
        {
            Item.damage = 12; // Base damage dealt by the sword
            Item.DamageType = DamageClass.Melee; // Specifies melee damage type
            Item.width = 40; // Item's hitbox width
            Item.height = 40; // Item's hitbox height
            Item.useTime = 20; // Time in frames to use the item
            Item.useAnimation = 20; // Animation duration in frames
            Item.useStyle = ItemUseStyleID.Swing; // Swinging use style
            Item.knockBack = 6; // Knockback applied on hit
            Item.value = Item.buyPrice(silver: 15); // Item's value in coins
            Item.rare = ItemRarityID.White; // Rarity color
            Item.UseSound = SoundID.Item1; // Sound played on use
            Item.autoReuse = false; // Does not auto-reuse
        }

        // Adds the crafting recipe for the CardboardSword
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<Cardboard>(12); // Requires 12 Cardboard
            recipe.AddTile(TileID.WorkBenches); // Crafted at a Work Bench
            recipe.Register(); // Registers the recipe
        }
    }
}
