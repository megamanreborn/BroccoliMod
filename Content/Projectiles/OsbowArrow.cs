using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace BroccoliMod.Content.Projectiles
{
    public class OsbowArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // Optionally configure projectile behavior here
        }

        public override void SetDefaults() {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.light = 1;
            Projectile.arrow = true;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 1200;
            Projectile.penetrate = -1; // Unlimited penetration, handled manually
        }

        // Tracks the number of bounces this arrow has performed
        private int bounceCount = 0;

        public override void AI() {
            // Apply gravity after a short delay
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

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            bounceCount++;

            // Reverse X velocity if hitting a wall
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = -oldVelocity.X * 0.7f;
            }
            // Reverse Y velocity if hitting the ground or ceiling
            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.velocity.Y = -oldVelocity.Y * 0.7f;
            }

            // Destroy the arrow after 3 bounces
            if (bounceCount >= 3)
            {
                Projectile.Kill();
            }

            // Destroy the arrow if it slows down too much
            if (Projectile.velocity.Length() < 1f)
            {
                Projectile.Kill();
            }

            // Return false to prevent vanilla tile collision behavior
            return false;
        }
    }
}