using General.Interfaces;
using UnityEngine;

namespace General
{
    public abstract class InteractiveObject : MonoBehaviour, IInitialization, IExecute
    {
        private bool _isInteractable = true;

        protected bool IsInteractable
        {
            get { return _isInteractable; }
            private set
            {
                _isInteractable = value;
                gameObject.SetActive(_isInteractable);
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction(other.gameObject);
            IsInteractable = false;
        }

        protected abstract void Interaction(GameObject player);
        public abstract void Execute(float deltaTime);

        public void Initialization()
        {
            IsInteractable = true;
        }
    }
}