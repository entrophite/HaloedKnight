using HarmonyLib;

namespace HolyKnight.Patches
{
	[HarmonyPatch(typeof(HeroController))]
	[HarmonyPatch(nameof(HeroController.TakeDamage))]
	internal class Invulnerable
	{
		static bool Prefix()
		{
			return !Plugin.config_invulnerable.Value;
		}
	}
}
