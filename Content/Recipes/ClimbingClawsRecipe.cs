using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

public class ClimbingClawsRecipe : ModSystem

{
	public override void AddRecipes() {

		Recipe ClimbingClawsRecipe = Recipe.Create(ItemID.ClimbingClaws);

		ClimbingClawsRecipe.AddRecipeGroup("IronBar", 10);
		ClimbingClawsRecipe.AddTile(TileID.Anvils);

		ClimbingClawsRecipe.Register();

	}

}