using BroccoliMod.Content.Projectiles;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BroccoliMod.Content.Items
{
    // Defines the Osyo yoyo item
    public class Osyo : ModItem
    {
        public override void SetStaticDefaults() {
            // Mark this item as a yoyo
            ItemID.Sets.Yoyo[Item.type] = true;
            // Increase yoyo range for gamepad users
            ItemID.Sets.GamepadExtraRange[Item.type] = 12;
            // Enable smart quick reach for gamepad users
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
        }

        public override void SetDefaults()
        {
            // Set item size
            Item.width = 24;
            Item.height = 24;
            // Set item use style and animation
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 25;
            Item.useAnimation = 25;
            // Yoyos are not melee weapons directly and don't show their graphic
            Item.noMelee = true;
            Item.noUseGraphic = true;
            // Set use sound
            Item.UseSound = SoundID.Item1;
            // Set damage and type
            Item.damage = 27;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.knockBack = 3f;
            Item.crit = 4;
            // Channeling allows holding the yoyo out
            Item.channel = true;
            // Set item value and rarity
            Item.value = Item.buyPrice(gold: 1);
            Item.shoot = ModContent.ProjectileType<OsyoProj>(); // The yoyo projectile
            Item.shootSpeed = 16f;
            Item.rare = ItemRarityID.Green;
        }
    }
}