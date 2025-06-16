using Terraria;
using Terraria.ID;
using BroccoliMod.Content.Projectiles;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace BroccoliMod.Content.Items
{
    public class WiiRemote : ModItem
    {
        public override void SetDefaults()
        {
            // Set base stats for the Wii Remote melee weapon
            Item.damage = 13;
            Item.knockBack = 4f;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 7;
            Item.useTime = 7;
            Item.width = 32;
            Item.height = 32;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;

            // Rarity, value, and projectile assignment
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.shoot = ModContent.ProjectileType<WiiRemoteProj>();
            Item.shootSpeed = 2.1f;
        }

        // AddRecipes can be implemented here if crafting is desired
    }
}