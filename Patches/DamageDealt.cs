using HarmonyLib;

namespace HolyKnight.Patches
{
	[HarmonyPatch(typeof(GetNailDamage))]
	[HarmonyPatch(nameof(GetNailDamage.OnEnter))]
	internal class DamageDealt
	{
		static void Postfix(ref GetNailDamage __instance)
		{
			Plugin.Log.LogInfo(__instance);
			__instance.storeValue.Value = (int)(__instance.storeValue.Value * Plugin.config_damage_dealt_multiplier.Value);
			return;
		}
	}
}
