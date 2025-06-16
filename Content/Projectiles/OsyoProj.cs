using BroccoliMod.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BroccoliMod.Content.Projectiles
{
    public class OsyoProj : ModProjectile
    {
        public override void SetStaticDefaults() {
            // Set yoyo lifetime, range, and speed
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 6f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 300f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 13f;
        }

        public override void SetDefaults() {
            // Configure yoyo projectile hitbox and behavior
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = ProjAIStyleID.Yoyo;
            Projectile.light = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.penetrate = -1;
        }

        public override void PostAI() {
            // Emit snow dust occasionally while the yoyo is active
            if (Main.rand.NextBool(5)) {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Snow>());
            }
        }
    }
}

