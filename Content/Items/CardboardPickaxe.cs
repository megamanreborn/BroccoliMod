using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using BroccoliMod.Content.Items;

namespace BroccoliMod.Content.Items
{
    // Defines the CardboardPickaxe item for the mod
    public class CardboardPickaxe : ModItem
    {
        // Sets the default properties of the item
        public override void SetDefaults() {
            Item.damage = 6; // Base damage dealt by the pickaxe
            Item.DamageType = DamageClass.Melee; // Specifies melee damage type
            Item.width = 40; // Item's hitbox width
            Item.height = 40; // Item's hitbox height
            Item.useTime = 10; // Time in frames to use the item
            Item.useAnimation = 10; // Animation duration in frames
            Item.useStyle = ItemUseStyleID.Swing; // Swinging use style
            Item.knockBack = 6; // Knockback applied on hit
            Item.value = Item.buyPrice(silver: 15); // Item's value in coins
            Item.rare = ItemRarityID.White; // Rarity color
            Item.UseSound = SoundID.Item1; // Sound played on use
            Item.autoReuse = true; // Allows continuous use when held

            Item.pick = 45; // Pickaxe power
            Item.attackSpeedOnlyAffectsWeaponAnimation = true; // Attack speed only affects animation
        }

        // Adds the crafting recipe for the CardboardPickaxe
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<Cardboard>(10); // Requires 10 Cardboard
            recipe.AddIngredient(ItemID.Wood, 3); // Requires 3 Wood
            recipe.AddTile(TileID.WorkBenches); // Crafted at a Work Bench
            recipe.Register(); // Registers the recipe
        }
    }
}