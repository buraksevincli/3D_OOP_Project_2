using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Inputs;
using GameFolders.Scripts.Concretes.Inputs;
using GameFolders.Scripts.Concretes.Movements;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;
        
        private HorizontalMover _horizontalMover;
        private JumpWithRigidbody _jumpWithRigidbody;
        private IInputReader _input;

        private float _horizontal;
        private bool _isJump;

        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jumpWithRigidbody = new JumpWithRigidbody(this);
            _input = new InputReader(GetComponent<PlayerInput>());
        }

        private void FixedUpdate()
        {
            _horizontalMover.TickFixed(_horizontal, moveSpeed);

            if (_isJump)
            {
                _jumpWithRigidbody.TickFixed(jumpForce);
            }
            
            _isJump = false;
        }

        private void Update()
        {
            _horizontal = _input.Horizontal;
            _isJump = _input.IsJump;
            Debug.Log($"_isJump: {_isJump}");
            Debug.Log($"_input: {_input.IsJump}");
        }
    }
}

