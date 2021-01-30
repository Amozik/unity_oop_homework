using System;
using System.Collections;
using General.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace General
{
    public class CameraController : IExecute
    {
        private Transform _player;
        private Transform _mainCamera;
        
        private Vector3 _offset;
        private Vector3 _originalOffset;

        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
            _mainCamera.LookAt(_player);
            _offset = _mainCamera.position - _player.position;
        }

        public void Execute(float deltaTime)
        {
            _mainCamera.position = _player.position + _offset;
        }
        
        public void Shake (float duration, float amount)
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
    }
}