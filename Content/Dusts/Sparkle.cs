using Terraria;
using Terraria.ModLoader;

namespace BroccoliMod.Content.Dusts
{
	public class Sparkle : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.velocity *= 0.4f; // Multiply the dust's start velocity by 0.4, slowing it down
			dust.noGravity = true; // Makes the dust have no gravity.
			dust.noLight = true; // Makes the dust emit no light.
			dust.scale *= 1.5f; // Multiplies the dust's initial scale by 1.5.
		}

		public override bool Update(Dust dust) { // Calls every frame the dust is active
			dust.position += dust.velocity; // Updates the dust's position by adding its velocity to its current position.
			dust.rotation += dust.velocity.X * 0.15f; // Rotates the dust based on its X velocity, multiplied by 0.15f for a slower rotation.
			dust.scale *= 0.99f; // Decreases the dust's scale by 1% every frame.

			float light = 0.35f * dust.scale; // Calculates the light intensity based on the dust's scale, with a base value of 0.35f.
 
			Lighting.AddLight(dust.position, light, light, light); // Adds light to the dust's position based on its scale.

			if (dust.scale < 0.5f) {
				dust.active = false;  // Deactivate the dust when its scale is less than 0.5
			}

			return false; // Return false to prevent vanilla behavior.
		}
	}
}