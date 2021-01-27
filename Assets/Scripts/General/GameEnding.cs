using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace General
{
    public class GameEnding : MonoBehaviour
    {
        private  CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Display()
        {
            StartCoroutine(Show(1.5f));
        }
        
        private IEnumerator Show (float duration) {
            var startTime = Time.time;
            var endTime = Time.time + duration;

            while (Time.time < endTime) {
                _canvasGroup.alpha = (Time.time - startTime) / duration;;

                yield return null;
            }
        }
    }
}