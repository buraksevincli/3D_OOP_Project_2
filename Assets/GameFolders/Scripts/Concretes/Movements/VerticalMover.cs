using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.Controllers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class VerticalMover
    {
        private EnemyController _enemyController;

        private float _moveSpeed;

        public VerticalMover(EnemyController enemyController)
        {
            _enemyController = enemyController;
            _moveSpeed = enemyController.MoveSpeed;
        }

        public void FixedTick(float vertical = 1)
        {
            _enemyController.transform.Translate(Vector3.back * (vertical * Time.deltaTime * _moveSpeed));
        }
    }
}

