using System;
using Dreamteck.Splines;
using Enums;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public event Action ClickToStart;
        
        [SerializeField]
        private SplineComputer _splineComputer;
        private CanvasManager _canvasManager;
        public bool IsStartGame { get; private set; }
        public bool IsEndGame { get; private set; }

        [Inject]
        private void Construct (CanvasManager canvasManager)
        {
            _canvasManager = canvasManager;
        }

        private void Start()
        {
            _splineComputer.triggerGroups[0].triggers[0].onCross.AddListener(Win); 
        }

        private void StartPlay()
        {
            ClickToStart?.Invoke();
            IsStartGame = true;
        }

        private void Win (SplineUser arg0)
        {
            _canvasManager.ShowWindow(eUIWindow.Win);
            IsEndGame = true;
        }
        public void Lose ()
        {
            _canvasManager.ShowWindow(eUIWindow.Lose);
            IsEndGame = true;
        }

        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        public void Update ()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    if(!IsStartGame && !IsEndGame) 
                        StartPlay();

                    else if (IsEndGame)
                        Restart();
                }
            }
        }
    }
}
