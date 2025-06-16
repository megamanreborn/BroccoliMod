using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BroccoliMod.Content.Items
{
    public class SunplateArrow : ModItem
    {
        public override void SetStaticDefaults() {
            // Number of arrows needed to research for duplication in Journey mode
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults() {
            // Arrow sprite size
            Item.width = 14;
            Item.height = 36;

            // Arrow base damage and type
            Item.damage = 10;
            Item.DamageType = DamageClass.Ranged;

            // Stack and consumable settings
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;

            // Knockback and value
            Item.knockBack = 1.5f;
            Item.value = Item.sellPrice(silver: 1);

            // Projectile and ammo settings
            Item.shoot = ModContent.ProjectileType<Projectiles.SunplateArrowProjectile>();
            Item.shootSpeed = 3f;
            Item.ammo = AmmoID.Arrow;
        }

        // Adds the crafting recipe for Sunplate Arrows
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(100);
            recipe.AddIngredient(ItemID.SunplateBlock, 10);
            recipe.AddTile(305); // Sky Mill
            recipe.Register();
        }
    }
}