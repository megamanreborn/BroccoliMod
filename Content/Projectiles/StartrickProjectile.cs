using BroccoliMod.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BroccoliMod.Content.Projectiles
{
    public class StartrickProjectile : ModProjectile
    {
        public override void SetStaticDefaults() {
            // Configure yoyo lifetime, range, and speed
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 6f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 300f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 13f;
        }

        public override void SetDefaults() {
            // Set hitbox and yoyo behavior
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = ProjAIStyleID.Yoyo;
            Projectile.light = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.penetrate = -1;
        }

        public override void PostAI() {
            // Emit sparkle dust while the yoyo is active
            if (Main.rand.NextBool(5)) {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Sparkle>());
            }
        }
    }
}

