using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace BroccoliMod.Content.Projectiles
{
    public class SunplateArrowProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // Configure projectile properties if needed
        }

        public override void SetDefaults() {
            // Set hitbox size and basic arrow properties
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.light = 1;
            Projectile.arrow = true;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 1200;
        }

        public override void AI() {
            // Apply gravity after a short delay for a natural arc
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 15f) {
                Projectile.ai[0] = 15f;
                Projectile.velocity.Y += 0.1f;
            }

            // Rotate the arrow to match its velocity direction
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            // Limit maximum downward speed
            if (Projectile.velocity.Y > 16f) {
                Projectile.velocity.Y = 16f;
            }
        }

        public override void OnKill(int timeLeft) {
            // Play a sound and spawn dust when the arrow is destroyed
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            for (int i = 0; i < 5; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Silver);
                dust.noGravity = true;
                dust.velocity *= 1.5f;
                dust.scale *= 0.9f;
            } 
        }
    }
}