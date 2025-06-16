using BroccoliMod.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BroccoliMod.Content.Items
{
    // Defines the CrystalKatana item for the mod
    public class CrystalKatana : ModItem
    {
        // Sets the default properties of the item
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Katana); // Copies properties from the base Katana

            Item.damage *= 3; // Triples the base damage
            Item.useTime = 14; // Sets a faster use time
            Item.crit = 29; // Sets critical strike chance
            Item.rare = 2; // Sets item rarity
        }

        // Adds the crafting recipe for the CrystalKatana
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Katana, 1); // Requires 1 Katana
            recipe.AddIngredient(ItemID.CrystalShard, 50); // Requires 50 Crystal Shards
            recipe.AddIngredient(ItemID.SoulofLight, 10); // Requires 10 Souls of Light
            recipe.AddTile(TileID.MythrilAnvil); // Crafted at a Mythril Anvil
            recipe.Register(); // Registers the recipe
        }
    }
}
