using System;
using System.Collections;
using General.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace General
{
    public class GameController : MonoBehaviour, IDisposable
    {
        [SerializeField] 
        private LevelConfig _levelConfig;

        [SerializeField]
        private GameEnding _gameEnding;
        
        public static GameController Instance = null;
        
        private ListExecuteObject _interactiveObjects;
        private DisplayBonuses _displayBonuses;
        private CameraController _cameraController;
        private InputController _inputController;
        private int _points;
        private Reference _reference;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            Object.Instantiate(_levelConfig.prefab);
            
            _interactiveObjects = new ListExecuteObject();

            _reference = new Reference();
            
            _cameraController = new CameraController(_reference.PlayerBaseBall.transform, _reference.MainCamera.transform);
            _interactiveObjects.AddExecuteObject(_cameraController);
            
            _inputController = new InputController(_reference.PlayerBaseBall);
            _interactiveObjects.AddExecuteObject(_inputController);
            
            _displayBonuses = new DisplayBonuses(_reference.Score, _levelConfig.totalPoints);
            
            _gameEnding = new GameEnding(_reference.EndGame)
            {
                RestartGame = RestartGame
            };

            foreach (var interactiveObject in _interactiveObjects)
            {
                //interactiveObject.Initialization(displayBonuses);

                if (interactiveObject is GoodBonus goodBonus)
                {
                    goodBonus.OnCollectPoint += OnCollectPoint;
                } else if (interactiveObject is DeathBonus deathBonus)
                {
                    deathBonus.OnDeath += OnDeathPlayer;
                }
            }
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        }
        
        private void OnDeathPlayer()
        {
            Time.timeScale = 0.0f;
            _gameEnding.Display("Game Over");
        }
        
        private void OnCollectPoint(int points)
        {
            _points += points;
            _displayBonuses.Display(points);
            _cameraController.Shake(.5f,.5f );

            if (_points == _levelConfig.totalPoints)
            {
                _gameEnding.Display("You Win");
            }
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                
                interactiveObject.Execute(deltaTime);
            }
        }
        
        public void Dispose()
        {
            foreach (var interactiveObject in _interactiveObjects)
            {
                if (interactiveObject is GoodBonus goodBonus)
                {
                    goodBonus.OnCollectPoint -= OnCollectPoint;
                } else if (interactiveObject is DeathBonus deathBonus)
                {
                    deathBonus.OnDeath -= OnDeathPlayer;
                }
            }
        }

    }
}