using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

public class ShackleRecipe : ModSystem

{
	public override void AddRecipes() {

		Recipe ShackleRecipe = Recipe.Create(ItemID.Shackle);

		ShackleRecipe.AddRecipeGroup("IronBar", 5);
		ShackleRecipe.AddTile(TileID.Anvils);

		ShackleRecipe.Register();

	}

}