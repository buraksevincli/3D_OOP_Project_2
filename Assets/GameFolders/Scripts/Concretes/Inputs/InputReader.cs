using GameFolders.Scripts.Abstracts.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameFolders.Scripts.Concretes.Inputs
{
    public class InputReader : IInputReader
    {
        private PlayerInput _playerInput;

        public float Horizontal { get; private set; }
        public bool IsJump { get; private set; }

        public InputReader(PlayerInput playerInput)
        {
            _playerInput = playerInput;
            
            _playerInput.currentActionMap.actions[0].performed += OnHorizontalMove;
            _playerInput.currentActionMap.actions[1].started += OnJump;
            _playerInput.currentActionMap.actions[1].canceled += OnJump;
        }

        private void OnJump(InputAction.CallbackContext context)
        {
            IsJump = context.ReadValueAsButton();
        }

        private void OnHorizontalMove(InputAction.CallbackContext context)
        {
            Horizontal = context.ReadValue<float>();
        }
    }
}

