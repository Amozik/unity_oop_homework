using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using General.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace General
{
    public class CameraController : ILateExecute, IInitialization, ICleanup
    {
        private Transform _player;
        private Transform _mainCamera;
        
        private Vector3 _offset;
        private Vector3 _originalOffset;

        private List<GoodBonus> _bonuses;

        public CameraController(Transform player, Transform mainCamera, IEnumerable<InteractiveObject> bonuses)
        {
            _player = player;
            _mainCamera = mainCamera;
            _mainCamera.LookAt(_player);
            _offset = _mainCamera.position - _player.position;
            
            _bonuses = new List<GoodBonus>();

            foreach (var bonus in bonuses)
            {
                if (bonus is GoodBonus goodBonus)
                {
                    _bonuses.Add(goodBonus);
                }
            }
            //_bonuses = (IEnumerable<GoodBonus>) bonuses.Where(bonus => bonus is GoodBonus);
        }

        public void LateExecute(float deltaTime)
        {
            _mainCamera.position = _player.position + _offset;
        }
        
        public void Initialization()
        {
            foreach (var bonus in _bonuses)
            {
                bonus.OnCollectPoint += OnCollectPoint;
            }
        }

        private void OnCollectPoint(int points)
        {
            Shake(.5f,.5f);
        }

        private void Shake (float duration, float amount)
        {
            _originalOffset = _offset;
            GameController.Instance.StopCoroutine(cShake(duration, amount));
            GameController.Instance.StartCoroutine(cShake(duration, amount));
        }

        private IEnumerator cShake (float duration, float amount) {
            float endTime = Time.time + duration;

            while (Time.time < endTime) {
                _offset = _originalOffset + Random.insideUnitSphere * amount;
                
                duration -= Time.deltaTime;

                yield return null;
            }

            _offset = _originalOffset;
        }
        
        public void Cleanup()
        {
            foreach (var bonus in _bonuses)
            {
                bonus.OnCollectPoint -= OnCollectPoint;
            }
        }
    }
}