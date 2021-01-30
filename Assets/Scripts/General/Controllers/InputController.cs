using General.Interfaces;
using UnityEngine;

namespace General
{
    public class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;
        
        public InputController(PlayerBase player)
        {
            _playerBase = player;
        }
        public void Execute(float deltaTime)
        {
            _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        }
    }
}