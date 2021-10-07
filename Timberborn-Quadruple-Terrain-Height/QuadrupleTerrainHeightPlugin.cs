using BepInEx;
using System.Reflection;
using Timberborn.Core;
using Timberborn.MapSystemUI;

namespace TimberbornQuadrupleTerrainHeight
{
    [BepInPlugin("org.bepinex.plugins.quadrupleterrainheight", "Quadruple Terrainheight", "1.0.2")]
    public class QuadrupleTerrainHeightPlugin : BaseUnityPlugin
    {
	public void Awake()
	{
	    var height = typeof(MapSize).GetField("MaxTerrainHeight", BindingFlags.Static | BindingFlags.Public);
	    var size = typeof(NewMapBox).GetField("MaxMapSize", BindingFlags.Static | BindingFlags.NonPublic);
	    height.SetValue(null, (int)height.GetValue(null) * 4);
	    size.SetValue(null, (int)size.GetValue(null) * 4);
	}
    }
}
