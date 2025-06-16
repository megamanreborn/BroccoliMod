using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace BroccoliMod.Content.Items
{
    [AutoloadEquip(EquipType.Beard)]
    public class Osnose : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Set static display properties here if needed
        }

        public override void SetDefaults()
        {
            // Set item properties
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            Item.rare = 2;
            Item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Enable the Osnose effect for the player when this accessory is equipped
            player.GetModPlayer<FrostburnPlayer>().Osnose = true;
        }
    }

    public class FrostburnPlayer : ModPlayer
    {
        // Tracks whether the Osnose effect is active
        public bool Osnose;

        public override void ResetEffects()
        {
            // Reset the Osnose effect each tick
            Osnose = false;
        }

        // Spawn projectiles whenever the player takes any damage
        public override void OnHurt(Player.HurtInfo info)
        {
            if (Osnose)
            {
                SpawnIceBoltRain();
            }
        }

        private void SpawnIceBoltRain()
        {
            for (int i = 0; i < 3; i++)
            {
                float xOffset = Main.rand.NextFloat(-60f, 61f);
                Vector2 spawnPos = Player.Center + new Vector2(xOffset, -400f);
                Vector2 velocity = new Vector2(0, 12f);
                if (Main.myPlayer == Player.whoAmI)
                {
                    Projectile.NewProjectile(
                        Player.GetSource_Misc("Osnose"),
                        spawnPos,
                        velocity,
                        ProjectileID.IceBolt,
                        12,
                        2f,
                        Player.whoAmI
                    );
                }
            }
        }
    }
}