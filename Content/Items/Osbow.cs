using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using BroccoliMod.Content.Items;
using BroccoliMod.Content.Projectiles;

namespace BroccoliMod.Content.Items
{
    public class Osbow : ModItem
    {
        // Set the default properties of the bow item
        public override void SetDefaults() {
            Item.damage = 21; // Base damage
            Item.useStyle = ItemUseStyleID.Shoot; // Bow use style
            Item.width = 12; // Item hitbox width
            Item.height = 38; // Item hitbox height
            Item.maxStack = 1; // Not stackable
            Item.useTime = 28; // Time between uses
            Item.useAnimation = 28; // Animation duration
            Item.useStyle = 5; // Use style (redundant, but matches vanilla bows)
            Item.knockBack = 2; // Knockback strength
            Item.value = 1500; // Sell value in copper coins
            Item.rare = 2; // Rarity
            Item.UseSound = SoundID.Item5; // Bow use sound
            Item.noMelee = true; // Doesn't deal melee damage itself
            Item.shoot = 1; // Default projectile type (arrow)
            Item.useAmmo = AmmoID.Arrow; // Uses arrows as ammo
            Item.shootSpeed = 10f; // Projectile speed
            Item.autoReuse = false; // No auto-reuse
        }

        // Change the projectile type if using wooden arrows
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = ModContent.ProjectileType<OsbowArrow>(); // Replace with custom arrow
            }
        }
    }
}



