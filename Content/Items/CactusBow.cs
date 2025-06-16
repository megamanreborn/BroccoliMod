using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using BroccoliMod.Content.Items;

namespace BroccoliMod.Content.Items
{
    // Defines the CactusBow item for the mod
    public class CactusBow : ModItem
    {
        // Sets the default properties of the item
        public override void SetDefaults() {
            Item.damage = 6; // Base damage dealt by the bow
            Item.useStyle = ItemUseStyleID.Shoot; // Use style for shooting
            Item.width = 12; // Item's hitbox width
            Item.height = 38; // Item's hitbox height
            Item.maxStack = 1; // Only one can be stacked
            Item.useTime = 28; // Time in frames to use the item
            Item.useAnimation = 28; // Animation duration in frames
            Item.useStyle = ItemUseStyleID.Shoot; // Use style for shooting
            Item.knockBack = 2; // Knockback applied on hit
            Item.value = 1500; // Item's value in coins
            Item.rare = ItemRarityID.White; // Rarity color
            Item.UseSound = SoundID.Item5; // Sound played on use
            Item.noMelee = true; // Does not deal melee damage
            Item.shoot = ProjectileID.WoodenArrowFriendly; // Shoots wooden arrows by default
            Item.useAmmo = AmmoID.Arrow; // Uses arrows as ammo
            Item.shootSpeed = 10f; // Speed of the shot projectile
            Item.autoReuse = false; // Does not auto-reuse
        }

        // Adds the crafting recipe for the CactusBow
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Cactus, 10); // Requires 10 Cactus
            recipe.AddTile(TileID.WorkBenches); // Crafted at a Work Bench
            recipe.Register(); // Registers the recipe
        }
    }
}



