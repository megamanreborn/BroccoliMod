using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BroccoliMod.Content.Items;

namespace BroccoliMod.Content.Items
{ 
    public class WaterEdge : ModItem
    {
        public override void SetDefaults()
        {
            // Set base stats for the Water Edge sword
            Item.damage = 10;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            // Fires a Water Bolt projectile on use
            Item.shoot = ProjectileID.WaterBolt;
            Item.shootsEveryUse = false;
            Item.shootSpeed = 6f;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(silver: 167);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            // Recipe: 1 Water Bolt + 15 Iron/Lead Bars at an Anvil
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WaterBolt, 1);
            recipe.AddRecipeGroup("IronBar", 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
