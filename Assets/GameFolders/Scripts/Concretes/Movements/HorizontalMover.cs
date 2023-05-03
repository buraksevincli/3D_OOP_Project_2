using GameFolders.Scripts.Abstracts.Controllers;
using GameFolders.Scripts.Abstracts.Movements;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class HorizontalMover : IMover
    {
        private IEntityController _entityController;

        private float _moveSpeed;
        private float _moveBoundary;

        public HorizontalMover(IEntityController entityController)
        {
            _entityController = entityController;
            _moveSpeed = entityController.MoveSpeed;
            _moveBoundary = entityController.MoveBoundary;
        }

        public void FixedTick(float horizontal)
        {
            if(horizontal == 0f) return;
            

            Transform playerTransform = _entityController.transform;
            Vector3 playerPosition = playerTransform.position;
            
            playerTransform.Translate(Vector3.right * (horizontal * Time.deltaTime * _moveSpeed));

            float xBoundary = Mathf.Clamp(playerTransform.position.x, -_moveBoundary, _moveBoundary);

            playerPosition = new Vector3(xBoundary, playerPosition.y, playerPosition.z);

            playerTransform.position = playerPosition;
        }
    }
}

