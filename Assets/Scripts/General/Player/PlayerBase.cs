using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace General
{
    public abstract class PlayerBase : MonoBehaviour
    {
        public float Speed = 3f;

        // private Rigidbody _rigidbody;
        //
        // private void Start()
        // {
        //     _rigidbody = GetComponent<Rigidbody>();
        // }
        
        public abstract void Move(float x, float y, float z);

        public void AddSpeed(float value, float time)
        {
            this.Speed += value;
            StartCoroutine(RollBackSpeed(value, time));

        }
        
        private IEnumerator RollBackSpeed(float value, float waitForSeconds)
        {
            yield return new WaitForSeconds(waitForSeconds);
            this.Speed -= value;
        }
    }
}
