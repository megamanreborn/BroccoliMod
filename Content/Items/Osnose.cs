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

        // Called when the player is hit by an NPC
        public override void OnHitByNPC(NPC npc, Player.HurtInfo hurtInfo)
        {
            if (Osnose)
            {
                SpawnIceBoltRain();
            }
        }

        // Called when the player is hit by a projectile
        public override void OnHitByProjectile(Projectile proj, Player.HurtInfo hurtInfo)
        {
            if (Osnose)
            {
                SpawnIceBoltRain();
            }
        }

        // Spawns a rain of Ice Bolt projectiles above the player
        private void SpawnIceBoltRain()
        {
            for (int i = 0; i < 3; i++)
            {
                // Random horizontal offset for each bolt
                float xOffset = Main.rand.NextFloat(-60f, 61f);
                // Spawn position above the player
                Vector2 spawnPos = Player.Center + new Vector2(xOffset, -400f);
                // Downward velocity
                Vector2 velocity = new Vector2(0, 12f);
                // Only spawn projectiles for the local player
                if (Main.myPlayer == Player.whoAmI)
                {
                    Projectile.NewProjectile(
                        Player.GetSource_Misc("Osnose"),
                        spawnPos,
                        velocity,
                        ProjectileID.IceBolt, // Projectile type
                        12,                   // Damage
                        2f,                   // Knockback
                        Player.whoAmI         // Owner
                    );
                }
            }
        }
    }
}