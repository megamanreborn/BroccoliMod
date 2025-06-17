using BroccoliMod.Content.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace BroccoliMod.Content.Projectiles
{
    public class FleshBallProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.SnowBallFriendly);
            AIType = ProjectileID.SnowBallFriendly;
            Projectile.penetrate += 2;
            Projectile.scale = 0.8f;
        }

        // Spawn blood dust and play sound when hitting a block
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            SpawnBloodDust();
            SoundEngine.PlaySound(SoundID.NPCHit19, Projectile.position);
            return base.OnTileCollide(oldVelocity);
        }

        // Spawn blood dust and play sound when projectile dies
        public override void OnKill(int timeLeft)
        {
            SpawnBloodDust();
            SoundEngine.PlaySound(SoundID.NPCHit19, Projectile.position);
            base.OnKill(timeLeft);
        }

        private void SpawnBloodDust()
        {
            for (int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Blood);
                Main.dust[dust].velocity *= 1.5f;
            }
        }
    }
}