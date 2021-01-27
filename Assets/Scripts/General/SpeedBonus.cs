using System.Collections;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace General
{
    public class SpeedBonus : InteractiveObject, IFlay
    {
        [SerializeField]
        private float _speedBonus = 1f;
        [SerializeField]
        private float _timeBonus = 1f;
        
        [SerializeField]
        private Vector3 _offcetPosition = Vector3.zero;
        
        private Vector3 _localPosition;

        private void Awake()
        {
            _localPosition = transform.localPosition;
        }
        
        protected override void Interaction(GameObject player)
        {
            var playerScript = player.GetComponent<Player>();

            playerScript.AddSpeed(_speedBonus, _timeBonus);
        }

        public void Flay()
        {
            transform.position = Vector3.Lerp(_localPosition, _localPosition + _offcetPosition,
                Mathf.PingPong(Time.time, 1));
        }
    }
}