using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Utilities;
using GameFolders.Scripts.Concretes.Controllers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class EnemyManager : SingletonMonoBehaviourObject<EnemyManager>
    {
        [SerializeField] private EnemyController enemyPrefab;

        private Queue<EnemyController> _enemies = new Queue<EnemyController>();

        private void Awake()
        {
            SingletonThisGameObject(this);
        }

        private void Start()
        {
            InitializePool();
        }

        private void InitializePool()
        {
            for (int i = 0; i < 10; i++)
            {
                EnemyController newEnemy = Instantiate(enemyPrefab);

                newEnemy.gameObject.SetActive(false);
                newEnemy.transform.parent = this.transform;

                _enemies.Enqueue(newEnemy);
            }
        }

        public void SetPool(EnemyController enemyController)
        {
            enemyController.gameObject.SetActive(false);
            enemyController.transform.parent = this.transform;
            
            _enemies.Enqueue(enemyController);
        }

        public EnemyController GetPool()
        {
            if (_enemies.Count == 0)
            {
                InitializePool();
            }
            
            return _enemies.Dequeue();
        }
    }
}

