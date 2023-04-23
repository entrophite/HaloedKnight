using HarmonyLib;

namespace HolyKnight.Patches
{
	[HarmonyPatch(typeof(HeroController))]
	[HarmonyPatch("Update")]
	internal class InfiniteSoul
	{
		static bool Prefix(ref HeroController __instance)
		{
			if (Plugin.config_infinite_soul.Value)
				__instance.playerData.MPCharge = __instance.playerData.maxMP;
			return true;
		}
	}
}
