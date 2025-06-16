using Terraria;
using Terraria.ID;
using BroccoliMod.Content.Projectiles;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace BroccoliMod.Content.Items
{
    // Defines the Shortfury item
    public class Shortfury : ModItem
    {
        public override void SetDefaults()
        {
            // Set base damage and knockback
            Item.damage = 29;
            Item.knockBack = 4f;
            // Use rapier style and animation
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 17;
            Item.useTime = 17;
            // Set item size
            Item.width = 32;
            Item.height = 32;
            // Set use sound
            Item.UseSound = SoundID.Item1;
            // Set damage type
            Item.DamageType = DamageClass.MeleeNoSpeed;
            // Enable auto reuse, hide graphic, and disable direct melee hitbox
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            // Set rarity and value
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            // Set projectile and speed
            Item.shoot = ModContent.ProjectileType<ShortfuryBlade>();
            Item.shootSpeed = 2.1f;
        }

        // Called when the item is used to shoot a projectile
        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Get mouse position in the world
            Vector2 mouseWorld = Main.MouseWorld;
            // Spawn the star projectile above the mouse with random horizontal offset
            Vector2 spawnPosition = mouseWorld + new Vector2(Main.rand.NextFloat(-100, 100), -1100);
            Vector2 starVelocity = new Vector2(0, 16f);

            int starType = ProjectileID.Starfury;

            // Spawn the Starfury star projectile
            Projectile.NewProjectile(source, spawnPosition, starVelocity, starType, damage, knockback, player.whoAmI);

            return true;
        }

        // Adds the crafting recipe for the Shortfury
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Starfury, 1);
            recipe.AddIngredient<File>(1); // Custom ingredient
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}