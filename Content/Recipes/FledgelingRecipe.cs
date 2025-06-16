using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

public class FledgelingRecipe : ModSystem

{
	public override void AddRecipes() {

		Recipe FledgelingRecipe = Recipe.Create(ItemID.CreativeWings);

		FledgelingRecipe.AddIngredient(ItemID.FallenStar, 3);
        FledgelingRecipe.AddIngredient(ItemID.Feather, 15);
		FledgelingRecipe.AddTile(TileID.Anvils);

		FledgelingRecipe.Register();

	}

}