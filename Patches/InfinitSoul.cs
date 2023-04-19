using HarmonyLib;

namespace HolyKnight.Patches
{
	[HarmonyPatch(typeof(HeroController))]
	[HarmonyPatch(nameof(HeroController.TakeMP))]
	internal class InfiniteSoul
	{
		static bool Prefix()
		{
			return !Plugin.config_infinite_soul.Value;
		}
	}
}
