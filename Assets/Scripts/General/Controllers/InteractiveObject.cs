using General.Interfaces;
using UnityEngine;

namespace General
{
    public abstract class InteractiveObject : MonoBehaviour, IExecute
    {
        protected IView _view;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }
            Interaction(other.gameObject);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }

        protected abstract void Interaction(GameObject player);
        public abstract void Execute(float deltaTime);

        public void Initialization(IView view)
        {
            _view = view;
        }
    }
}