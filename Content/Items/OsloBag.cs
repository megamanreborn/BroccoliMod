using BroccoliMod.Content.Items;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace BroccoliMod.Content.Items
{
    public class OsloBag : ModItem
    {
        // Set static properties for the boss bag
        public override void SetStaticDefaults()
        {
            ItemID.Sets.BossBag[Type] = true; // Mark as a boss bag
            ItemID.Sets.PreHardmodeLikeBossBag[Type] = true; // Pre-Hardmode boss bag
            Item.ResearchUnlockCount = 3; // Number needed for research
        }

        // Set default item properties
        public override void SetDefaults()
        {
            Item.maxStack = Item.CommonMaxStack; // Max stack size
            Item.consumable = true; // Can be consumed (opened)
            Item.width = 24; // Item width
            Item.height = 24; // Item height
            Item.rare = ItemRarityID.Purple; // Rarity color
            Item.expert = true; // Expert mode item
        }

        // Allow right-click to open the bag
        public override bool CanRightClick()
        {
            return true;
        }

        // Define the loot dropped when the bag is opened
        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.OneFromOptions(1,
                ModContent.ItemType<OsloStaff>(), // Possible drop: OsloStaff
                ModContent.ItemType<Osyo>(),      // Possible drop: Osyo
                ModContent.ItemType<Osbow>()));   // Possible drop: Osbow

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<WiiRemote>(), 100)); // Rare drop: WiiRemote 1%
            itemLoot.Add(ItemDropRule.Common(ItemID.Snowball, 1, 50, 201));           // Drop: Snowballs always
            itemLoot.Add(ItemDropRule.Common(ItemID.IceBlock, 1, 50, 101));           // Drop: Ice Blocks always
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Osnose>(), 1, 1, 1));// Drop: Osnose always
        }
    }
}