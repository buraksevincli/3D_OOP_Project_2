using GameFolders.Scripts.Concretes.Controllers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class JumpWithRigidbody
    {
        private Rigidbody _rigidbody;

        public JumpWithRigidbody(PlayerController playerController)
        {
            _rigidbody = playerController.GetComponent<Rigidbody>();
        }

        public void TickFixed(float jumpForce)
        {
            if (_rigidbody.velocity.y != 0) return;
            
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up * (Time.deltaTime * jumpForce));
        }
    }
}

