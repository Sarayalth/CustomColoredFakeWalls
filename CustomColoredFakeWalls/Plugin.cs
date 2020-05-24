using BeatSaberMarkupLanguage.Settings;
using BS_Utils.Utilities;
using HarmonyLib;
using IPA;
using IPALogger = IPA.Logging.Logger;
namespace CustomColoredFakeWalls
{
	[Plugin(RuntimeOptions.SingleStartInit)]
	public class Plugin
	{
		internal static Plugin instance { get; private set; }
		internal static string Name => "CustomColoredFakeWalls";
		internal static IPALogger log { get; set; }
		[Init]
		public void Init(IPALogger logger)
		{
			instance = this;
			log = logger;
		}
		[OnStart]
		public void OnApplicationStart()
		{
			BSEvents.menuSceneLoadedFresh += BSEvents_menuSceneLoadedFresh;
			Harmony harmony = new Harmony("com.Sarayalth.CustomColoredFakeWalls");
			harmony.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());
		}

		private void BSEvents_menuSceneLoadedFresh()
		{
			BSMLSettings.instance.AddSettingsMenu("<size=75%>CustomColoredFakeWalls</size>", "CustomColoredFakeWalls.UI.Settings.bsml", UI.Settings.instance);
		}

		[OnExit]
		public void OnApplicationQuit(){}
	}
}
