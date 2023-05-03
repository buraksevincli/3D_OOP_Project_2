using GameFolders.Scripts.Abstracts.Controllers;
using GameFolders.Scripts.Abstracts.Movements;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class VerticalMover : IMover
    {
        private IEntityController _entityController;

        public VerticalMover(IEntityController entityController)
        {
            _entityController = entityController;
        }

        public void FixedTick(float vertical = 1)
        {
            _entityController.transform.Translate(Vector3.back * (vertical * Time.deltaTime * _entityController.MoveSpeed));
        }
    }
}

