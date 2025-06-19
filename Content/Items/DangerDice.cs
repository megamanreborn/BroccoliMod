using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BroccoliMod.Content.Projectiles;

namespace BroccoliMod.Content.Items
{
    // Represents the "Danger Dice" item, a custom ranged weapon for the mod
    public class DangerDice : ModItem
    {
        // Sets static properties for the item (e.g., research unlock count)
        public override void SetStaticDefaults()
        {
            // Number of items needed to unlock research duplication in Journey Mode
            Item.ResearchUnlockCount = 99;
        }

        // Sets the default properties and behavior of the item
        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Green; // Item rarity color
            Item.value = Item.sellPrice(gold: 1); // Sell price in gold
            Item.useStyle = ItemUseStyleID.Swing; // How the item is used (swinging motion)
            Item.useAnimation = 25; // Animation duration in ticks
            Item.useTime = 25; // Time between uses in ticks
            Item.UseSound = SoundID.Item1; // Sound played on use
            Item.autoReuse = true; // Allows continuous use while holding the button
            Item.damage = 10; // Base damage dealt
            Item.knockBack = 5f; // Knockback strength
            Item.noUseGraphic = true; // Hides the item's use graphic
            Item.noMelee = true; // Prevents melee damage
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged
            Item.shootSpeed = 6f; // Speed of the projectile shot
            Item.shoot = ModContent.ProjectileType<DangerDiceProj>(); // Projectile to shoot
        }
    }
}