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
            //_canvasGroup.alpha = 0;
        }

        public void Display()
        {
            StartCoroutine(Show(1.5f));
        }
        
        private IEnumerator Show (float duration) {
            var startTime = Time.unscaledTime;
            var endTime = Time.unscaledTime + duration;

            while (Time.unscaledTime < endTime) {
                _canvasGroup.alpha = (Time.unscaledTime - startTime) / duration;;

                yield return null;
            }
        }
    }
}