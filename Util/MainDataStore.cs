using AdvancedRoadTools.UI;
using ColossalFramework;
using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace AdvancedRoadTools.Util
{
    public class MainDataStore
    {
        public static float[] segmentModifiedMinOffset = new float[262144];
        public static byte[] SaveData = new byte[1048576];
        public static void Save()
        {
            int i = 0;
            SaveAndRestore.save_floats(ref i, segmentModifiedMinOffset, ref SaveData);
        }

        public static void Load()
        {
            int i = 0;
            segmentModifiedMinOffset = SaveAndRestore.load_floats(ref i, SaveData, segmentModifiedMinOffset.Length);
        }

        private Vector3 GetScaleMesh()
        {
            if (float.TryParse(ScaleUI.scaleX.text, out float result1) && float.TryParse(ScaleUI.scaleY.text, out float result2) && float.TryParse(ScaleUI.scaleZ.text, out float result3))
            {
                return new Vector3(result1, result2, result3);
            }
            return Vector3.one;
        }
    }
}
