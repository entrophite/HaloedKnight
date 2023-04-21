using HarmonyLib;

namespace HolyKnight.Patches
{
	[HarmonyPatch(typeof(HeroController))]
	[HarmonyPatch("CanAttack")]
	internal class SpammingAttackCooldown
	{
		static AccessTools.FieldRef<HeroController, float> attack_cooldown_ref = 
			AccessTools.FieldRefAccess<HeroController, float>("attack_cooldown");
		static bool Prefix(ref HeroController __instance)
		{
			if (Plugin.config_spamming_attack.Value)
				attack_cooldown_ref(__instance) = 0f;
			return true;
		}
	}

	[HarmonyPatch(typeof(HeroController))]
	[HarmonyPatch("Attack")]
	internal class SpammingAttackDuration
	{
		static AccessTools.FieldRef<HeroController, float> attackDuration_ref =
			AccessTools.FieldRefAccess<HeroController, float>("attackDuration");
		static void Postfix(ref HeroController __instance)
		{
			if (Plugin.config_spamming_attack.Value)
				attackDuration_ref(__instance) = 0f;
			return;
		}
	}
}
