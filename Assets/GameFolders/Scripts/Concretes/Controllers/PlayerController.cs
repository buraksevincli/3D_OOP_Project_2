using GameFolders.Scripts.Abstracts.Controllers;
using GameFolders.Scripts.Abstracts.Inputs;
using GameFolders.Scripts.Abstracts.Movements;
using GameFolders.Scripts.Concretes.Inputs;
using GameFolders.Scripts.Concretes.Managers;
using GameFolders.Scripts.Concretes.Movements;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class PlayerController : MyCharacterController, IEntityController
    {
        
        [SerializeField] private float jumpForce;
        
        private IMover _mover;
        private IInputReader _input;
        private JumpWithRigidbody _jumpWithRigidbody;

        private float _horizontal;
        private bool _isJump;
        private bool _isDead = false;

        private void Awake()
        {
            _mover = new HorizontalMover(this);
            _jumpWithRigidbody = new JumpWithRigidbody(this);
            _input = new InputReader(GetComponent<PlayerInput>());
        }

        private void FixedUpdate()
        {
            _mover.FixedTick(_horizontal);

            if (_isJump)
            {
                _jumpWithRigidbody.FixedTick(jumpForce);
            }
            _isJump = false;
        }

        private void Update()
        {
            Debug.Log($"_isJump {_isJump}");
            Debug.Log($"_input {_input.IsJump}");
            
            if(_isDead) return;
            
            _horizontal = _input.Horizontal;

            _isJump = _input.IsJump;
        }

        private void OnTriggerEnter(Collider other)
        {
            IEntityController entityController = other.GetComponent<IEntityController>();

            if (entityController != null)
            {
                GameManager.Instance.StopGame();
                _isDead = true;
            }
        }
    }
}

