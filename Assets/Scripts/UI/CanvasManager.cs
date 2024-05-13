using Enums;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace UI
{
    public class CanvasManager : MonoBehaviour
    {
        private WindowConfig _windowConfig;

        [Inject]
        private void Construct(GameConfig gameConfig)
        {
            _windowConfig = gameConfig.WindowConfig;
        }
        public void ShowWindow (eUIWindow window)
        {
            Instantiate(_windowConfig.GetCanvas(window), transform);
        }
    }
}