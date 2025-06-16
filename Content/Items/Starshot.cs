using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using BroccoliMod.Content.Items;

namespace BroccoliMod.Content.Items
{
    public class Starshot : ModItem
    {
        public override void SetDefaults() {
            // Set base damage for the weapon
            Item.damage = 17;
            // Set the use style to shooting (bow/gun)
            Item.useStyle = ItemUseStyleID.Shoot;
            // Set item dimensions
            Item.width = 12;
            Item.height = 38;
            // Only one can be stacked
            Item.maxStack = 1;
            // Set use time and animation duration
            Item.useTime = 24;
            Item.useAnimation = 24;
            // Set knockback strength
            Item.knockBack = 2;
            // Set item value in copper coins
            Item.value = 15000;
            // Set item rarity
            Item.rare = 2;
            // Set the sound played when used
            Item.UseSound = SoundID.Item5;
            // Prevents melee damage with the item itself
            Item.noMelee = true;
            // Default projectile type (overridden by ammo)
            Item.shoot = 1;
            // Uses arrows as ammo
            Item.useAmmo = AmmoID.Arrow;
            // Set projectile speed
            Item.shootSpeed = 10f;
            // Does not auto-reuse when held down
            Item.autoReuse = false;
        }

        // Adds the crafting recipe for the Starshot
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            // Requires 20 Cloud
            recipe.AddIngredient(ItemID.Cloud, 20);
            // Requires 30 Sunplate Block
            recipe.AddIngredient(ItemID.SunplateBlock, 30);
            // Requires 3 Fallen Stars
            recipe.AddIngredient(ItemID.FallenStar, 3);
            // Crafted at the Sky Mill (tile 305)
            recipe.AddTile(305);
            recipe.Register();
        }
    }
}