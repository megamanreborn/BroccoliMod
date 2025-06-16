using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BroccoliMod.Content.Items;

public class PaperAirRecipe : ModSystem

{
	public override void AddRecipes() {

		Recipe PaperAirRecipe = Recipe.Create(ItemID.PaperAirplaneB);

        PaperAirRecipe.AddIngredient(ModContent.ItemType<Paper>());
		PaperAirRecipe.AddTile(TileID.WorkBenches);

		PaperAirRecipe.Register();

	}

}