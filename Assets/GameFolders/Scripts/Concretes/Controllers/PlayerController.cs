using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.Movements;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float horizontalDirection;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] private bool isJump;
        
        private HorizontalMover _horizontalMover;
        private JumpWithRigidbody _jumpWithRigidbody;

        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jumpWithRigidbody = new JumpWithRigidbody(this);
        }

        private void FixedUpdate()
        {
            _horizontalMover.TickFixed(horizontalDirection, moveSpeed);

            if (isJump)
            {
                _jumpWithRigidbody.TickFixed(jumpForce);
            }
            
            isJump = false;
        }
    }
}

