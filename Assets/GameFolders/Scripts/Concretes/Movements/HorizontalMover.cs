using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.Controllers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class HorizontalMover
    {
        private PlayerController _playerController;

        private float _moveSpeed;
        private float _moveBoundary;

        public HorizontalMover(PlayerController playerController)
        {
            _playerController = playerController;
            _moveSpeed = _playerController.MoveSpeed;
            _moveBoundary = _playerController.MoveBoundary;
        }

        public void TickFixed(float horizontal)
        {
            if(horizontal == 0f) return;

            Transform playerTransform = _playerController.transform;
            Vector3 playerPosition = playerTransform.position;
            
            playerTransform.Translate(Vector3.right * (horizontal * Time.deltaTime * _moveSpeed));

            float xBoundary = Mathf.Clamp(playerTransform.position.x, -_moveBoundary, _moveBoundary);

            playerPosition = new Vector3(xBoundary, playerPosition.y, playerPosition.z);

            playerTransform.position = playerPosition;
        }
    }
}

