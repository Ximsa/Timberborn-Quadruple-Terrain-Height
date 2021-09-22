using BepInEx;
using System.Reflection;
using Timberborn.Core;

namespace TimberbornQuadrupleTerrainHeight
{
    [BepInPlugin("org.bepinex.plugins.quadrupleterrainheight", "Quadruple Terrainheight", "1.0.0.1")]
    public class QuadrupleTerrainHeightPlugin : BaseUnityPlugin
    {
        public void Awake()
        {
            typeof(MapSize).GetField("MaxTerrainHeight", BindingFlags.Static | BindingFlags.Public).SetValue(null,64);
        }
    }
}