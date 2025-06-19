using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BroccoliMod.Content.Projectiles;

namespace BroccoliMod.Content.Items
{
    public class DangerDice : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(gold: 1);
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.damage = 10;
            Item.knockBack = 5f;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Ranged;
            Item.shootSpeed = 6f;
            Item.shoot = ModContent.ProjectileType<DangerDiceProj>();
        }
    }
}