using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BroccoliMod.Content.Projectiles;

namespace BroccoliMod.Content.Items
{
    public class TheStinger : ModItem
    {
        public override void SetDefaults()
        {
            // Set weapon stats and behavior
            Item.damage = 27;
            Item.knockBack = 3f;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.width = 32;
            Item.height = 32;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;

            // Set rarity and value
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 0, 8);

            // Set projectile and speed
            Item.shoot = ModContent.ProjectileType<StingerBlade>();
            Item.shootSpeed = 2.1f;
        }

        // Adds the crafting recipe for The Stinger
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Stinger, 3);
            recipe.AddIngredient(ItemID.JungleSpores, 8);
            recipe.AddIngredient(ItemID.Vine, 2); // Note: duplicate ingredient
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}