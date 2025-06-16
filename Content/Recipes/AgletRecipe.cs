using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

public class AgletRecipe : ModSystem

{
	public override void AddRecipes() {

		Recipe AgletRecipe = Recipe.Create(ItemID.Aglet);

		AgletRecipe.AddRecipeGroup("IronBar", 5);
		AgletRecipe.AddTile(TileID.Anvils);

		AgletRecipe.Register();

	}

}