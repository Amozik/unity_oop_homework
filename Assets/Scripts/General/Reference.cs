using UnityEngine;

namespace General
{
    public class Reference
    {
        private PlayerBall _playerBaseBall;
        private Camera _mainCamera;
        private GameObject _score;
        private GameObject _endGame;
        private Canvas _canvas;

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                
                return _canvas;
            }
        }

        public GameObject Score
        {
            get
            {
                if (_score == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/Score");
                    _score = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _score;
            }
        }

        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/GameEnding");
                    _endGame = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _endGame;
            }
        }

        public PlayerBall PlayerBaseBall
        {
            get
            {
                if (_playerBaseBall == null)
                {
                    var gameObject = Resources.Load<PlayerBall>("Player");
                    _playerBaseBall = Object.Instantiate(gameObject);
                }
                
                return _playerBaseBall;
            }
        }
        
        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }
    }
}