using HarmonyLib;

namespace HolyKnight.Patches
{
	[HarmonyPatch(typeof(HeroController))]
	[HarmonyPatch("CanDoubleJump")]
	internal class InfiniteDoubleJump
	{
		static void Postfix(ref bool __result)
		{
			__result |= Plugin.config_infinite_double_jump.Value;
			return;
		}
	}
}
