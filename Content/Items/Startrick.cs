using BroccoliMod.Content.Projectiles;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BroccoliMod.Content.Items
{
    public class Startrick : ModItem
    {
        public override void SetStaticDefaults() {
            // Register this item as a yoyo and stuff for gamepad controls i think
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = 10;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
        }

        public override void SetDefaults() {
            // Set hitbox size
            Item.width = 24;
            Item.height = 24;
            // Yoyo use style and animation
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 25;
            Item.useAnimation = 25;
            // Yoyos use projectiles for damage
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item1;
            // Weapon stats
            Item.damage = 23;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.knockBack = 2.5f;
            Item.crit = 4;
            Item.channel = true;
            Item.value = Item.buyPrice(gold: 1);
            // Assign projectile and speed
            Item.shoot = ModContent.ProjectileType<StartrickProjectile>();
            Item.shootSpeed = 16f;
        }

        // Adds the crafting recipe for the Startrick yoyo
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Cloud, 30);
            recipe.AddIngredient(ItemID.SunplateBlock, 20);
            recipe.AddIngredient(ItemID.FallenStar, 5);
            recipe.AddTile(305); // Sky Mill
            recipe.Register();
        }
    }
}