using UnityEngine;

namespace General
{
    public class DearthBonus : InteractiveObject, IFlay
    {
        [SerializeField]
        private Vector3 _offcetPosition = Vector3.zero;
        
        private Vector3 _localPosition;

        private void Awake()
        {
            _localPosition = transform.localPosition;
        }
        protected override void Interaction(GameObject player)
        {
            Destroy(player);
        }

        public void Flay()
        {
            transform.position = Vector3.Lerp(_localPosition, _localPosition + _offcetPosition,
                Mathf.PingPong(Time.time, 1));
        }
    }
}