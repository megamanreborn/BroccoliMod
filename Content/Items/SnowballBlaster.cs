using BroccoliMod.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BroccoliMod.Content.Items
{
    // Defines the Snowball Blaster item
    public class SnowballBlaster : ModItem
    {
        public override void SetDefaults()
        {
            // Clone the base stats from the Snowball Cannon
            Item.CloneDefaults(ItemID.SnowballCannon);
            // Increase damage
            Item.damage *= 4;
            // Double the projectile speed
            Item.shootSpeed *= 2f;
            // Faster use time
            Item.useTime = 14;
            // Increase critical chance
            Item.crit *= 1;
        }

        public override void AddRecipes()
        {
            // Crafting recipe for the Snowball Blaster
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SnowballCannon, 1);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
