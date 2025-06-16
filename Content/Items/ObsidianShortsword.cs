using Terraria;
using Terraria.ID;
using BroccoliMod.Content.Projectiles;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Enums;


namespace BroccoliMod.Content.Items
{
    public class ObsidianShortsword : ModItem
    {
        // Set the default properties of the item
        public override void SetDefaults()
        {
            Item.damage = 38; // Base damage
            Item.knockBack = 4f; // Knockback strength
            Item.useStyle = ItemUseStyleID.Rapier; // Rapier-style use animation
            Item.useAnimation = 17; // Animation time
            Item.useTime = 17; // Time between uses
            Item.width = 32; // Item hitbox width
            Item.height = 32; // Item hitbox height
            Item.UseSound = SoundID.Item1; // Sound when used
            Item.DamageType = DamageClass.MeleeNoSpeed; // Melee weapon, no attack speed scaling
            Item.autoReuse = true; // Can be used repeatedly by holding the button
            Item.noUseGraphic = true; // Don't show the item graphic when used, the projectile is what is shown
            Item.noMelee = true; // The item itself doesn't deal melee damage, the projectile does

            Item.rare = ItemRarityID.Blue; // Rarity color
            Item.value = Item.sellPrice(0, 0, 0, 10); // Sell price in copper coins

            Item.shoot = ModContent.ProjectileType<ObsidianBlade>(); // Shoots a custom projectile
            Item.shootSpeed = 2.1f; // Projectile speed
        }
        
        // Define the crafting recipe for the item
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Obsidian, 50); // Requires 50 Obsidian
            recipe.AddTile(TileID.Hellforge); // Crafted at a Hellforge
            recipe.Register();
        }

        // Called when the player is holding the item
        public override void HoldItem(Player player)
        {
            if (player.itemAnimation > 0 && player.HeldItem == Item)
            {
                // Set a custom glow effect on the player while swinging
                player.GetModPlayer<ObsidianSwordPlayer>().obsidianSwordGlow = 1f;
            }
        }
    }
}