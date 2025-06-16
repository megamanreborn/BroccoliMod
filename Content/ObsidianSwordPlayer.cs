using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

//Ignore how this file is named, It was originally only for the Obsidian Shortsword but now handles multiple sword glow effects.

namespace BroccoliMod.Content
{
    public class ObsidianSwordPlayer : ModPlayer
    {
        public float obsidianSwordGlow = 0f;
        public float hellstoneSwordGlow = 0f;
        public bool greenSwordGlow = false;
        public float joyeuseSwordGlow = 0f;

        public override void ResetEffects()
        {
            // Gradually fade out each sword's glow effect
            if (obsidianSwordGlow > 0f)
            {
                obsidianSwordGlow -= 0.05f;
                if (obsidianSwordGlow < 0f)
                    obsidianSwordGlow = 0f;
            }

            if (hellstoneSwordGlow > 0f)
            {
                hellstoneSwordGlow -= 0.05f;
                if (hellstoneSwordGlow < 0f)
                    hellstoneSwordGlow = 0f;
            }

            if (joyeuseSwordGlow > 0f)
            {
                joyeuseSwordGlow -= 0.05f;
                if (joyeuseSwordGlow < 0f)
                    joyeuseSwordGlow = 0f;
            }

            // Reset green glow every tick; only set by StingerBlade
            greenSwordGlow = false;
        }

        public override void PostUpdate()
        {
            // Add colored light to the player based on active sword glows
            if (obsidianSwordGlow > 0f)
            {
                Lighting.AddLight(Player.Center, 0.6f * obsidianSwordGlow, 0.1f * obsidianSwordGlow, 0.7f * obsidianSwordGlow);
            }
            if (hellstoneSwordGlow > 0f)
            {
                Lighting.AddLight(Player.Center, 0.9f * hellstoneSwordGlow, 0.4f * hellstoneSwordGlow, 0.05f * hellstoneSwordGlow);
            }
            if (greenSwordGlow)
            {
                Lighting.AddLight(Player.Center, 0f, 1f, 0f);
            }
            if (joyeuseSwordGlow > 0f)
            {
                Lighting.AddLight(Player.Center, 1f * joyeuseSwordGlow, 0.85f * joyeuseSwordGlow, 0.2f * joyeuseSwordGlow);
            }
        }
    }
}