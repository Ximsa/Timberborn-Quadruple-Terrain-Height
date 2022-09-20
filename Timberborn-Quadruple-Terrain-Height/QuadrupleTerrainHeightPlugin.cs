using BepInEx;
using System.Reflection;
using Timberborn.Core;
using Timberborn.MapSystemUI;

namespace TimberbornQuadrupleTerrainHeight
{
    [BepInPlugin("org.bepinex.plugins.quadrupleterrainheight", "Quadruple Terrainheight", "1.1.0")]
    public class QuadrupleTerrainHeightPlugin : BaseUnityPlugin
    {
        public void Awake()
        {
            var factor = 4;
            var height = typeof(MapSize).GetField("MaxMapEditorTerrainHeight", BindingFlags.Static | BindingFlags.Public);
            var maxGameTerrainHeight = typeof(MapSize).GetField("MaxGameTerrainHeight", BindingFlags.Static | BindingFlags.Public);
            var size = typeof(NewMapBox).GetField("MaxMapSize", BindingFlags.Static | BindingFlags.NonPublic);
            var diff = (int)maxGameTerrainHeight.GetValue(null) - (int)height.GetValue(null);
            height.SetValue(null, (int)height.GetValue(null) * factor);
            maxGameTerrainHeight.SetValue(null, (int)height.GetValue(null) + diff);
            size.SetValue(null, (int)size.GetValue(null) * factor);
        }
    }
}
