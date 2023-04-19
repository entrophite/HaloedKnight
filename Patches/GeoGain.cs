using HarmonyLib;

namespace HolyKnight.Patches
{
	[HarmonyPatch(typeof(HeroController))]
	[HarmonyPatch(nameof(HeroController.AddGeo))]
	internal class GeoGain
	{
		static bool Prefix(ref int amount)
		{
			amount = (int)(amount * Plugin.config_geo_gain_multiplier.Value);
			return true;
		}
	}
}
