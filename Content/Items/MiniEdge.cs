using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using BroccoliMod.Content.Projectiles;

namespace BroccoliMod.Content.Items
{
    public class MiniEdge : ModItem
    {
        // Set the default properties of the item
        public override void SetDefaults()
        {
            Item.damage = 31; // Base damage
            Item.knockBack = 5f; // Knockback strength
            Item.useStyle = ItemUseStyleID.Rapier; // Rapier-style use animation
            Item.useAnimation = 16; // Animation time
            Item.useTime = 16; // Time between uses
            Item.width = 32; // Item hitbox width
            Item.height = 32; // Item hitbox height
            Item.UseSound = SoundID.Item1; // Sound when used
            Item.DamageType = DamageClass.MeleeNoSpeed; // Melee weapon, no attack speed scaling
            Item.autoReuse = true; // Can be used repeatedly by holding the button
            Item.noUseGraphic = true; // Don't show the item graphic when used
            Item.noMelee = true; // The item itself doesn't deal melee damage
            Item.shoot = ModContent.ProjectileType<MiniEdgeBlade>(); // Shoots a custom projectile

            Item.rare = ItemRarityID.Orange; // Rarity color
            Item.value = Item.sellPrice(0, 0, 0, 50); // Sell price in copper coins
            Item.shootSpeed = 2.0f; // Projectile speed
        }

        // Define the crafting recipe for the item
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.NightsEdge, 1); // Requires Night's Edge
            recipe.AddIngredient<File>(1); // Placeholder for another ingredient
            recipe.AddTile(TileID.Anvils); // Crafted at an Anvil
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

        // Called when the item is used to shoot a projectile
        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int projType = ProjectileID.ShadowFlame; // Use the ShadowFlame projectile
            Projectile.NewProjectile(source, position, velocity, projType, damage, knockback, player.whoAmI);

            return true; // Also shoot the default projectile (MiniEdgeBlade)
        }
    }
}