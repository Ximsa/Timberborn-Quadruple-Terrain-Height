using BepInEx;
using HarmonyLib;
using System.Reflection;
using Timberborn.Core;
namespace TimberbornQuadrupleTerrainHeight
{
    [BepInPlugin("org.bepinex.plugins.quadrupleterrainheight", "Quarduple Terrainheight", "1.0.0.0")]
    public class QuadrupleTerrainHeightPlugin : BaseUnityPlugin
    {
        public void Awake()
        {
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "org.bepinex.plugins.quadrupleterrainheight");
        }
    }

    [HarmonyPatch(typeof(MapSize), "Initialize")]
    public static class TerrainHeightPatch //Initialize
    {
        [HarmonyPrefix]
        public static void setHeight(ref int ___MaxTerrainHeight) 
        {
            ___MaxTerrainHeight = 64;
        }
    }
}
