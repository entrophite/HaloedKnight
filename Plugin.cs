using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace HolyKnight
{
	[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
	public class Plugin : BaseUnityPlugin
	{
		internal static ManualLogSource Log;

		private void Awake()
		{
			// Plugin startup logic
			Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
			Log = Logger;

			// read config data
			LoadConfigs();

			var harmony = new Harmony("holy-knight");
			harmony.PatchAll();
		}

		// plugin configs
		internal static ConfigEntry<float> config_geo_gain_multiplier;
		internal static ConfigEntry<bool> config_invulnerable;
		internal static ConfigEntry<bool> config_infinite_soul;
		internal static ConfigEntry<float> config_damage_dealt_multiplier;
		internal static ConfigEntry<float> config_nail_range_multiplier;
		internal static ConfigEntry<bool> config_no_hard_landing;
		internal static ConfigEntry<bool> config_infinite_double_jump;

		internal void LoadConfigs()
		{
			config_geo_gain_multiplier = Config.Bind("GENERAL",
				"geo_gain_multiplier",
				1f);
			config_invulnerable = Config.Bind("GENERAL",
				"invulnerable",
				false);
			config_infinite_soul = Config.Bind("GENERAL",
				"infinite_soul",
				false);
			config_damage_dealt_multiplier = Config.Bind("GENERAL",
				"damage_dealt_multiplier",
				1f);
			config_nail_range_multiplier = Config.Bind("GENERAL",
				"nail_range_multiplier",
				1f);
			config_no_hard_landing = Config.Bind("GENERAL",
				"no_hard_landing",
				false,
				"do not trigger hard landing animation after falling from height");
			config_infinite_double_jump = Config.Bind("GENERAL",
				"infinite_double_jump",
				false);
		}
	}
}
