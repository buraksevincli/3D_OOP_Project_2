using GameFolders.Scripts.Abstracts.Controllers;
using GameFolders.Scripts.Concretes.Enums;
using GameFolders.Scripts.Concretes.Managers;
using GameFolders.Scripts.Concretes.Movements;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class EnemyController : MyCharacterController, IEntityController
    {
        [SerializeField] private EnemyEnum enemyEnum;
        [SerializeField] private float maxLifeTime = 10f;

        public EnemyEnum EnemyType => enemyEnum;
        
        private float _currentLifeTime = 0f;
        
        private VerticalMover _verticalMover;

        private void Awake()
        {
            _verticalMover = new VerticalMover(this);
        }

        private void FixedUpdate()
        {
            _verticalMover.FixedTick();
        }

        private void Update()
        {
            _currentLifeTime += Time.deltaTime;

            if (_currentLifeTime > maxLifeTime)
            {
                _currentLifeTime = 0;
                KillYourself();
            }
        }

        private void KillYourself()
        {
            EnemyManager.Instance.SetPool(this);
        }

        public void SetMoveSpeed(float moveSpeed)
        {
            if(moveSpeed < _moveSpeed) return;
            
            _moveSpeed = moveSpeed;
        }
    }
}

