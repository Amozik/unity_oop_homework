using UnityEngine;

namespace General
{
    public abstract class InteractiveObject : MonoBehaviour
    {
        protected IView _view;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }
            Interaction(other.gameObject);
            Destroy(gameObject);
        }

        protected abstract void Interaction(GameObject player);

        public void Initialization(IView view)
        {
            _view = view;
        }
    }
}