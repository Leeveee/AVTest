using Cinemachine;
using UnityEngine;
using Zenject;

namespace Core
{
    public class CameraSwitcher : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera [] _cameras;
      
        private int _currentCameraIndex;
        private GameManager _gameManager;

        [Inject]
        private void Construct (GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void OnEnable()
        {
            _gameManager.ClickToStart += ChangeStartCamera;
        }

        private void ChangeStartCamera()
        {
            if(!_gameManager.IsStartGame)
                SwitchNextCamera();
        }

        private void SwitchNextCamera()
        {
            foreach (CinemachineVirtualCamera virtualCamera in _cameras)
            {
                virtualCamera.Priority = 0;
            }

            _currentCameraIndex++;

            if (_currentCameraIndex >= _cameras.Length)
            {
                _currentCameraIndex = 0;
            }
      
            _cameras[_currentCameraIndex].Priority = 1;
        } 
    }
}