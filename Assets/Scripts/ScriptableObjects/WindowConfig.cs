using System;
using System.Linq;
using Enums;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "WindowConfig", menuName = "Configs/WindowConfig")]
    public class WindowConfig : ScriptableObject
    {
        [SerializeField]
        private Windows[] _windows;
        
        private Windows[] UIWindows =>_windows;

        public Canvas GetCanvas (eUIWindow window)
        {
            return _windows.First(canvas => canvas.Window == window).Canvas;
        }
        
        [Serializable]
        private class Windows
        {
            public Canvas Canvas;
            public eUIWindow Window;
        }
    }
}