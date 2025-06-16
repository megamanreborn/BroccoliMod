using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

public class FinchRecipe : ModSystem

{
	public override void AddRecipes() {

		Recipe FinchRecipe = Recipe.Create(ItemID.BabyBirdStaff);

		FinchRecipe.AddRecipeGroup("Wood", 25);
        FinchRecipe.AddIngredient(ItemID.Feather, 3);
		FinchRecipe.AddTile(TileID.WorkBenches);

		FinchRecipe.Register();

	}

}