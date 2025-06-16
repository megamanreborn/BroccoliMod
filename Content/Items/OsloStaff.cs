using BroccoliMod.Content.Projectiles;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace BroccoliMod.Content.Items
{
    public class OsloStaff : ModItem
    {
        // Set static properties for the staff
        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true; // Mark as a staff for proper use animation
        }
        // Set the default properties of the staff
        public override void SetDefaults()
        {
            Item.DefaultToStaff(ProjectileID.IceBolt, 16, 25, 6); // Set staff defaults (projectile, mana, damage, knockback)
            Item.UseSound = SoundID.Item20; // Sound when used
            Item.SetWeaponValues(31, 5); // Set damage and knockback
            Item.SetShopValues(ItemRarityColor.Green2, 10000); // Set rarity and value
            Item.useTime = 17; // Time between uses
            Item.useAnimation = 17; // Animation duration
        }
    }
}