using GameFolders.Scripts.Abstracts.Controllers;
using GameFolders.Scripts.Abstracts.Movements;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class HorizontalMover : IMover
    {
        private IEntityController _entityController;
        
        public HorizontalMover(IEntityController entityController)
        {
            _entityController = entityController;
        }

        public void FixedTick(float horizontal)
        {
            if(horizontal == 0f) return;
            

            Transform playerTransform = _entityController.transform;
            Vector3 playerPosition = playerTransform.position;
            
            playerTransform.Translate(Vector3.right * (horizontal * Time.deltaTime * _entityController.MoveSpeed));

            float xBoundary = Mathf.Clamp(playerTransform.position.x, -_entityController.MoveBoundary, _entityController.MoveBoundary);

            playerPosition = new Vector3(xBoundary, playerPosition.y, playerPosition.z);

            playerTransform.position = playerPosition;
        }
    }
}

