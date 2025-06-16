using BroccoliMod.Content.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace BroccoliMod.Content.Items
{
    public class JunglesRage : ModItem
    {
        // Set static properties for the item (e.g., special sets)
        public override void SetStaticDefaults() {
            ItemID.Sets.SkipsInitialUseSound[Item.type] = true; // Skip initial use sound
            ItemID.Sets.Spears[Item.type] = true; // Mark as a spear-type item
        }

        // Set the default properties of the item
        public override void SetDefaults() {
            Item.rare = ItemRarityID.Blue; // Item rarity
            Item.value = Item.sellPrice(silver: 10); // Sell price

            Item.useStyle = ItemUseStyleID.Shoot; // Use style (spear thrust)
            Item.useAnimation = 12; // Animation duration
            Item.useTime = 16; // Time between uses
            Item.UseSound = SoundID.Item71; // Sound when used
            Item.autoReuse = true; // Can be used repeatedly

            Item.damage = 19; // Base damage
            Item.knockBack = 6.5f; // Knockback strength
            Item.noUseGraphic = true; // Don't show item graphic when used
            Item.DamageType = DamageClass.Melee; // Melee weapon
            Item.noMelee = true; // The item itself doesn't deal melee damage

            Item.shootSpeed = 3.7f; // Projectile speed
            Item.shoot = ModContent.ProjectileType < JunglesRageProjectile>(); // Shoots custom projectile
        }

        // Only allow one spear projectile at a time
        public override bool CanUseItem(Player player) {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }

        // Play the use sound manually (since initial use sound is skipped)
        public override bool? UseItem(Player player) {
            if (!Main.dedServ && Item.UseSound.HasValue) {
                SoundEngine.PlaySound(Item.UseSound.Value, player.Center);
            }

            return null;
        }

        // Define the crafting recipe for the item
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.JungleSpores, 10); // Requires Jungle Spores
            recipe.AddIngredient(ItemID.Vine, 2); // Requires Vines
            recipe.AddIngredient(ItemID.Stinger, 3); // Requires Stingers
            recipe.AddTile(TileID.Anvils); // Crafted at an Anvil
            recipe.Register();
        }
    }
}