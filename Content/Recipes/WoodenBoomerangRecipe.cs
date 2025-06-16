using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

public class WoodenBoomerangRecipe : ModSystem

{
	public override void AddRecipes() {

		Recipe WoodenBoomerangRecipe = Recipe.Create(ItemID.WoodenBoomerang);

		WoodenBoomerangRecipe.AddRecipeGroup("Wood", 25);
		WoodenBoomerangRecipe.AddTile(TileID.WorkBenches);

		WoodenBoomerangRecipe.Register();

	}

}