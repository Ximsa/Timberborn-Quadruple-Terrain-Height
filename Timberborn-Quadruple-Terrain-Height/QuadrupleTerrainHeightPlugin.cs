
using System.Reflection;
using System;

using Timberborn.ModManagerScene;
using Timberborn.MapStateSystem;
using Timberborn.MapRepositorySystemUI;

namespace TimberbornQuadrupleTerrainHeight
{
    public class QuadrupleTerrainHeightPlugin : IModStarter
    {
        public void StartMod()
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
                .GetType("Timberborn.BrushesUI.BrushSizePanel, Timberborn.BrushesUI, Version = 0.0.0.0, Culture = neutral, PublicKeyToken = null")
                .GetField("MaxBrushSize", BindingFlags.Static | BindingFlags.NonPublic);
            brushSize.SetValue(null, (int)brushSize.GetValue(null) * factor);
        }
    }
}
