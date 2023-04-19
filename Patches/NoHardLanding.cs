using HarmonyLib;

namespace HolyKnight.Patches
{
	[HarmonyPatch(typeof(HeroController))]
	[HarmonyPatch("ShouldHardLand")]
	internal class NoHardLanding
	{
		static void Postfix(ref bool __result)
		{
			__result &= (!Plugin.config_no_hard_landing.Value);
			return;
		}
	}
}
