﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace General
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

            _rigidbody.AddForce(movement * _speed);
        }

        public void AddSpeed(float value, float time)
        {
            this._speed += value;
            StartCoroutine(RollBackSpeed(value, time));

        }
        
        private IEnumerator RollBackSpeed(float value, float waitForSeconds)
        {
            yield return new WaitForSeconds(waitForSeconds);
            this._speed -= value;
        }
    }
}