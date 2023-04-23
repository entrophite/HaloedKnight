using HarmonyLib;

namespace HolyKnight.Patches
{
	[HarmonyPatch(typeof(HeroController))]
	[HarmonyPatch("CanDash")]
	internal class NoDashCooldown
	{
		static AccessTools.FieldRef<HeroController, float> dashCooldownTimer_ref =
			AccessTools.FieldRefAccess<HeroController, float>("dashCooldownTimer");
		static AccessTools.FieldRef<HeroController, float> shadowDashTimer_ref =
			AccessTools.FieldRefAccess<HeroController, float>("shadowDashTimer");

		static bool Prefix(ref HeroController __instance)
		{
			if (Plugin.config_no_dash_cooldown.Value)
			{
				dashCooldownTimer_ref(__instance) = 0f;
				shadowDashTimer_ref(__instance) = 0f;
			}
			return true;
		}
	}
}
