using HarmonyLib;
using UnityEngine;

namespace HolyKnight.Patches
{
	[HarmonyPatch(typeof(NailSlash))]
	[HarmonyPatch(nameof(NailSlash.StartSlash))]
	internal class NailRange
	{
		static void Postfix(ref NailSlash __instance)
		{
			var s = Plugin.config_nail_range_multiplier.Value;
			var o = __instance.transform.localScale;
			__instance.transform.localScale = new Vector3(o.x * s, o.y * s, o.z);
			return;
		}
	}
}
