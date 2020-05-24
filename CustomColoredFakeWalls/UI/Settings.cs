using BeatSaberMarkupLanguage.Attributes;
using BS_Utils.Utilities;
using UnityEngine;
namespace CustomColoredFakeWalls.UI
{
	class Settings : PersistentSingleton<Settings>
	{
		public static Config config;
		public void Awake()
		{
			config = new Config("CustomColoredFakeWalls");
		}

		[UIValue("fast-walls-color")]
		public static Color FastWallsColor {
			get {
				var color = config.GetString("CustomColoredFakeWalls", "FastWallsColor", "#FFEB04FF");
				Color parsedColor;
				ColorUtility.TryParseHtmlString(color, out parsedColor);
				return parsedColor;
			}
			set {
				config.SetString("CustomColoredFakeWalls", "FastWallsColor", "#" + ColorUtility.ToHtmlStringRGBA(value));
			}
		}
		[UIValue("fast-walls-color-bool")]
		public static bool ApplyFastWallsColor {
			get => config.GetBool("CustomColoredFakeWalls", "ApplyFastWallsColor", false);
			set => config.SetBool("CustomColoredFakeWalls", "ApplyFastWallsColor", value);
		}

		[UIValue("fake-walls-color")]
		public static Color FakeWallsColor {
			get {
				var color = config.GetString("CustomColoredFakeWalls", "FakeWallsColor", "#00FF00FF");
				Color parsedColor;
				ColorUtility.TryParseHtmlString(color, out parsedColor);
				return parsedColor;
			}
			set {
				config.SetString("CustomColoredFakeWalls", "FakeWallsColor", "#" + ColorUtility.ToHtmlStringRGBA(value));
			}
		}
		[UIValue("fake-walls-color-bool")]
		public static bool ApplyFakeWallsColor {
			get => config.GetBool("CustomColoredFakeWalls", "ApplyFakeWallsColor", true);
			set => config.SetBool("CustomColoredFakeWalls", "ApplyFakeWallsColor", value);
		}
	}
}
