using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using BroccoliMod.Content.Projectiles;

namespace BroccoliMod.Content.Items
{
    // Defines the HellstoneShortsword item for the mod
    public class HellstoneShortsword : ModItem
    {
        // Sets the default properties of the item
        public override void SetDefaults()
        {
            Item.damage = 36; // Base damage dealt by the shortsword
            Item.knockBack = 5f; // Knockback applied on hit
            Item.useStyle = ItemUseStyleID.Rapier; // Rapier (shortsword) use style
            Item.useAnimation = 16; // Animation duration in frames
            Item.useTime = 16; // Time in frames to use the item
            Item.width = 32; // Item's hitbox width
            Item.height = 32; // Item's hitbox height
            Item.UseSound = SoundID.Item1; // Sound played on use
            Item.DamageType = DamageClass.MeleeNoSpeed; // Specifies melee damage type (no speed scaling)
            Item.autoReuse = true; // Allows continuous use when held
            Item.noUseGraphic = true; // Hides the item graphic when used
            Item.noMelee = true; // Does not deal melee damage directly
            Item.shoot = ModContent.ProjectileType<HellstoneBlade>(); // Shoots a custom projectile

            Item.rare = ItemRarityID.Orange; // Rarity color
            Item.value = Item.sellPrice(0, 0, 0, 50); // Item's value in coins
            Item.shootSpeed = 2.3f; // Speed of the shot projectile
        }

        // Adds the crafting recipe for the HellstoneShortsword
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FieryGreatsword, 1); // Requires 1 Fiery Greatsword
            recipe.AddIngredient<File>(1); // Requires 1 File (custom item)
            recipe.AddTile(TileID.Anvils); // Crafted at an Anvil
            recipe.Register(); // Registers the recipe
        }

        // Handles the shooting logic when the item is used
        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
        {
            // Shoots the main HellstoneBlade projectile
            Projectile.NewProjectile(source, position, velocity, type, damage, knockBack, player.whoAmI);

            // Shoots an additional flame projectile
            int flameDamage = damage / 2;
            int flameType = ProjectileID.Flames;
            Vector2 flameVelocity = velocity.SafeNormalize(Vector2.UnitX) * 6f;
            Projectile.NewProjectile(source, position, flameVelocity, flameType, flameDamage, 0f, player.whoAmI);

            return false; // Prevents vanilla projectile from being shot
        }

        // Adds a glow effect when the item is held
        public override void HoldItem(Player player)
        {
            if (player.itemAnimation > 0 && player.HeldItem == Item)
            {
                player.GetModPlayer<ObsidianSwordPlayer>().hellstoneSwordGlow = 1f;
            }
        }
    }
}