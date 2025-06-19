using BroccoliMod.Content.Dusts;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;

namespace BroccoliMod.Content.Projectiles
{
    public class DangerDiceProj : ModProjectile
    {
        private bool landed = false;
        private int landedTimer = 0;
        private const int LandedDuration = 120;

        public int faceValue = 0;

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
            Projectile.scale = 0.5f;
            Projectile.extraUpdates = 1;
        }

        public override void OnSpawn(IEntitySource source)
        {
            faceValue = Main.rand.Next(Main.projFrames[Projectile.type]);
            Projectile.frame = faceValue;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (landed)
                return false;

            // If hitting the ground (Y velocity reversed)
            if (oldVelocity.Y != Projectile.velocity.Y && Math.Abs(oldVelocity.Y) > 0.1f)
            {
                landed = true;
                Projectile.velocity = Vector2.Zero;
                Projectile.rotation = 0f;
                Projectile.netUpdate = true;
            }
            // If hitting a wall (X velocity reversed), bounce off and keep falling
            else if (oldVelocity.X != Projectile.velocity.X && Math.Abs(oldVelocity.X) > 0.1f)
            {
                Projectile.velocity.X = -oldVelocity.X * 0.2f; // dampen X velocity
                // Let gravity continue to act
            }
            return false;
        }

        public override void AI()
        {
            if (!landed)
            {
                // Only rotate if falling
                if (Math.Abs(Projectile.velocity.Y) > 0.01f)
                    Projectile.rotation += 0.2f;
                else
                    Projectile.rotation = 0f;

                Projectile.velocity.Y += 0.15f;
                if (Projectile.velocity.Y > 6f)
                    Projectile.velocity.Y = 6f;
            }
            else
            {
                // Always force velocity to zero when landed
                Projectile.velocity = Vector2.Zero;
                Projectile.rotation = 0f;
                landedTimer++;
                if (landedTimer >= LandedDuration)
                {
                    Projectile.Kill();
                }
            }
        }

        public override void PostAI()
        {
            Projectile.frameCounter = 0;
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            float[] multipliers = { 0.5f, 0.8f, 1.0f, 1.2f, 1.5f, 2.0f };
            float multiplier = multipliers[Math.Clamp(faceValue, 0, multipliers.Length - 1)];
            modifiers.SourceDamage *= multiplier;
        }

        [Obsolete]
        public override void Kill(int timeLeft)
        {
            // Emit sparkle dust from the bottom right of the sprite
            Vector2 emitPosition = Projectile.position + new Vector2(Projectile.width, Projectile.height);

            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(
                    emitPosition,
                    2, // Small area for emission
                    2,
                    ModContent.DustType<Sparkle>(),
                    Main.rand.NextFloat(-2f, 2f),
                    Main.rand.NextFloat(-2f, 2f)
                );
            }
        }
    }
}