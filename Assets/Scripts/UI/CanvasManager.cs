using System;
using System.Linq;
using Enums;
using UnityEngine;

namespace UI
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField]
        private Windows[] _windows;

        public void ShowWindow (eUIWindow window)
        {
            GetCanvas(window).gameObject.SetActive(true);
        }

        private Canvas GetCanvas (eUIWindow window)
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