using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

public class ShoeSpikesRecipe : ModSystem

{
	public override void AddRecipes() {

		Recipe ShoeSpikesRecipe = Recipe.Create(ItemID.ShoeSpikes);

		ShoeSpikesRecipe.AddRecipeGroup("IronBar", 10);
		ShoeSpikesRecipe.AddTile(TileID.Anvils);

		ShoeSpikesRecipe.Register();

	}

}