using BS_Utils.Utilities;
using CustomColoredFakeWalls.UI;
using HarmonyLib;
using UnityEngine;

namespace CustomColoredFakeWalls
{
	[HarmonyPatch(typeof(ObstacleController))]
	[HarmonyPatch("Init", MethodType.Normal)]
	class TextSegmentedControlCellNew_Patch
	{
		static void Postfix(ObstacleController __instance, ref ObstacleData ____obstacleData, ref StretchableObstacle ____stretchableObstacle)
		{
			if (____obstacleData.duration < 0 && Settings.ApplyFastWallsColor)
			{
				var fastWallColor = ScriptableObject.CreateInstance<SimpleColorSO>();
				fastWallColor.SetColor(Settings.FastWallsColor);
				var _obstacleFrame = __instance.GetComponent<StretchableObstacle>().GetPrivateField<ParametricBoxFrameController>("_obstacleFrame");
				__instance.GetComponent<StretchableObstacle>().SetSizeAndColor(_obstacleFrame.width, _obstacleFrame.height, _obstacleFrame.length, fastWallColor);
			}
			if (____obstacleData.width < 0 && Settings.ApplyFakeWallsColor)
			{
				var fakeWallColor = ScriptableObject.CreateInstance<SimpleColorSO>();
				fakeWallColor.SetColor(Settings.FakeWallsColor);
				var _obstacleFrame = __instance.GetComponent<StretchableObstacle>().GetPrivateField<ParametricBoxFrameController>("_obstacleFrame");
				__instance.GetComponent<StretchableObstacle>().SetSizeAndColor(_obstacleFrame.width, _obstacleFrame.height, _obstacleFrame.length, fakeWallColor);
			}
		}
	}
}
