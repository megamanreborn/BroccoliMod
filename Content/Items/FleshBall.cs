using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BroccoliMod.Content.Projectiles;

namespace BroccoliMod.Content.Items
{

    public class FleshBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(silver: 5);
            Item.maxStack = 999;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.consumable = true;

            Item.damage = 24;
            Item.knockBack = 5f;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Ranged;

            Item.shootSpeed = 12f;
            Item.shoot = ModContent.ProjectileType<Projectiles.FleshBallProj>();
        }
    }
}