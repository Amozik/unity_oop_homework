using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace General
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Player _player;

        private Vector3 _offset;
        private Vector3 _originalOffset;

        private void Start()
        {
            _offset = transform.position - _player.transform.position;
        }

        private void LateUpdate()
        {
            if (_player != null)
            {
                transform.position = _player.transform.position + _offset;
            }
        }
        
        public void Shake (float duration, float amount)
        {
            _originalOffset = _offset;
            StopAllCoroutines();
            StartCoroutine(cShake(duration, amount));
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