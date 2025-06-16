using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

public class HermesRecipe : ModSystem

{
	public override void AddRecipes() {

		Recipe HermesRecipe = Recipe.Create(ItemID.HermesBoots);

		HermesRecipe.AddIngredient(ItemID.Silk, 15);
        HermesRecipe.AddIngredient(ItemID.Feather, 3);
		HermesRecipe.AddTile(TileID.Loom);

		HermesRecipe.Register();

	}

}