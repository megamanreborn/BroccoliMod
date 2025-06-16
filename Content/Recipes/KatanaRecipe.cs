using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

public class KatanaRecipe : ModSystem

{
	public override void AddRecipes() {

		Recipe KatanaRecipe = Recipe.Create(ItemID.Katana);

		KatanaRecipe.AddRecipeGroup("IronBar", 15);
        KatanaRecipe.AddIngredient(ItemID.Silk, 10);
		KatanaRecipe.AddTile(TileID.Anvils);

		KatanaRecipe.Register();

	}

}