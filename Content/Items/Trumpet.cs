using BroccoliMod.Content.Projectiles;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace BroccoliMod.Content.Items
{
    public class Trumpet : ModItem
    {
        public override void SetStaticDefaults() {
            // Mark this item as a staff for visual effects
            Item.staff[Type] = true;
        }

        public override void SetDefaults() {
            // Set up as a magic staff using a note projectile as a placeholder
            Item.DefaultToStaff(ProjectileID.TiedEighthNote, 16, 25, 5);
            // Set the sound to a magic note sound
            Item.UseSound = SoundID.Item26;
            // Set weapon damage and knockback
            Item.SetWeaponValues(12, 5);
            // Set shop value and rarity
            Item.SetShopValues(ItemRarityColor.Blue1, 10000);
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, 
            Microsoft.Xna.Framework.Vector2 position, Microsoft.Xna.Framework.Vector2 velocity, int type, int damage, float knockback)
        {
            // Randomly select a musical note projectile to shoot
            int[] noteTypes = { ProjectileID.QuarterNote, ProjectileID.EighthNote, ProjectileID.TiedEighthNote };
            int chosenType = noteTypes[Main.rand.Next(noteTypes.Length)];
            // Slow down the projectile
            velocity *= 0.5f;
            // Spawn the chosen note projectile
            Projectile.NewProjectile(source, position, velocity, chosenType, damage, knockback, player.whoAmI);
            // Prevent the default projectile from spawning
            return false;
        }

        public override void AddRecipes()
        {
            // Recipe: 15 Iron/Lead Bars at an Anvil
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("IronBar", 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
