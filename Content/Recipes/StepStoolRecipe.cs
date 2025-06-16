using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

public class StepStoolRecipe : ModSystem

{
	public override void AddRecipes() {

		Recipe StepStoolRecipe = Recipe.Create(ItemID.PortableStool);

		StepStoolRecipe.AddRecipeGroup("Wood", 25);
		StepStoolRecipe.AddTile(TileID.Sawmill);

		StepStoolRecipe.Register();

	}

}