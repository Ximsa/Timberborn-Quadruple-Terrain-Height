using BepInEx;
using System.Reflection;
using Timberborn.Core;
using Timberborn.MapSystemUI;
using Timberborn.MapEditor;
using System;

namespace TimberbornQuadrupleTerrainHeight
{
    [BepInPlugin("org.bepinex.plugins.quadrupleterrainheight", "Quadruple Terrainheight", "1.2.0")]
    public class QuadrupleTerrainHeightPlugin : BaseUnityPlugin
    {
        public void Awake()
        {
            var factor = 4;
            // terrain height
            var maxEditorTerrainHeight = typeof(MapSize).GetField("MaxMapEditorTerrainHeight", BindingFlags.Static | BindingFlags.Public);
            var maxGameTerrainHeight = typeof(MapSize).GetField("MaxGameTerrainHeight", BindingFlags.Static | BindingFlags.Public);
            var diff = (int)maxGameTerrainHeight.GetValue(null) - (int)maxEditorTerrainHeight.GetValue(null);
            maxEditorTerrainHeight.SetValue(null, (int)maxEditorTerrainHeight.GetValue(null) * factor);
            maxGameTerrainHeight.SetValue(null, (int)maxEditorTerrainHeight.GetValue(null) + diff);
            // map size
            var maxMapSize = typeof(NewMapBox).GetField("MaxMapSize", BindingFlags.Static | BindingFlags.NonPublic);
            maxMapSize.SetValue(null, (int)maxMapSize.GetValue(null) * factor);
            // brush size
            var brushSize = Type
                .GetType("Timberborn.MapEditor.BrushSizePanel, Timberborn.MapEditor, Version = 0.0.0.0, Culture = neutral, PublicKeyToken = null")
                .GetField("MaxBrushSize", BindingFlags.Static | BindingFlags.NonPublic);
            brushSize.SetValue(null, (int)brushSize.GetValue(null) * factor);
        }
    }
}
