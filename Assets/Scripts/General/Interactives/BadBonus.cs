using UnityEngine;

namespace General
{
    public class BadBonus : InteractiveObject, IFlay, IFlicker
    {
        private Material _material;
        private float _lengthFlay;
        private Vector3 _localPosition;
        
        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(1.5f, 2.5f);
            _localPosition = transform.localPosition;
        }

        protected override void Interaction(GameObject player)
        {
           
        }
        
        public override void Execute(float deltaTime)
        {
            if(!IsInteractable){return;}
            Flay();
            Flicker();
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(_localPosition.x + Mathf.PingPong(Time.time, _lengthFlay) - _lengthFlay/2,
                _localPosition.y, 
                _localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }
    }
}