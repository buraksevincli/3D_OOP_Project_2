using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Controllers;
using GameFolders.Scripts.Abstracts.Movements;
using GameFolders.Scripts.Concretes.Controllers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class VerticalMover : IMover
    {
        private IEntityController _entityController;

        private float _moveSpeed;

        public VerticalMover(IEntityController entityController)
        {
            _entityController = entityController;
            // _moveSpeed = entityController.MoveSpeed;
        }

        public void FixedTick(float vertical = 1)
        {
            _entityController.transform.Translate(Vector3.back * (vertical * Time.deltaTime * _moveSpeed));
        }
    }
}

