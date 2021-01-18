using UnityEngine;

namespace General
{
    public class GoodBonus : InteractiveObject, IFlay, IRotation
    {
        [SerializeField]
        private int _points = 1;
        private float _lengthFlay;
        private float _speedRotation;
        
        private void Awake()
        {
            _lengthFlay = Random.Range(1.0f, 3.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
        }
        protected override void Interaction(GameObject player)
        {
            _view.Display(_points);
        }

        public void Flay()
        {
            var localPosition = transform.localPosition;
            localPosition = new Vector3(localPosition.x, 
                Mathf.PingPong(Time.time, _lengthFlay),
                localPosition.z);
            transform.localPosition = localPosition;
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }
    }
}