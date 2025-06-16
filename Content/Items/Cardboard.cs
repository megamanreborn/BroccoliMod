using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using BroccoliMod.Content.Items;

namespace BroccoliMod.Content.Items
{
	public class Cardboard : ModItem
	{
		public override void SetStaticDefaults() {

			Item.ResearchUnlockCount = 100;

		}

		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 20; 

			Item.maxStack = Item.CommonMaxStack; 
			Item.value = Item.buyPrice(silver: 1); 
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<WoodPulp>(2)
				.AddTile(TileID.Solidifier)
				.Register();
		}
	}
}