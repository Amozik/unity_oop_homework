using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace General
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] 
        private LevelConfig _levelConfig;

        [SerializeField]
        private CameraController _cameraController;

        [SerializeField]
        private GameEnding _gameEnding;
        
        private List<InteractiveObject> _interactiveObjects;

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>().ToList();
            var displayBonuses = new DisplayBonuses(_levelConfig.totalPoints);
            foreach (var interactiveObject in _interactiveObjects)
            {
                interactiveObject.Initialization(displayBonuses);

                if (interactiveObject is GoodBonus goodBonus)
                {
                    goodBonus.OnCollectPoint += OnCollectPoint;
                } else if (interactiveObject is DeathBonus deathBonus)
                {
                    deathBonus.OnDeath += _gameEnding.Display;
                }
            }
        }

        private void OnCollectPoint(int points)
        {
            _cameraController.Shake(.5f,.5f );
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Count; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFlay flay)
                {
                    flay.Flay();
                }
                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }
                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }
            }
        }
    }
}