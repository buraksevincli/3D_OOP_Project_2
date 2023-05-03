using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.Enums;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [Range(0.1f,5f)]
        [SerializeField] private float min = 0.1f;
        [Range(6f,15f)]
        [SerializeField] private float max = 15f;

        private float _maxSpawnTime;
        private float _currentSpawnTime = 0f;
        private int _index = 0;
        private float _maxAddEnemyTime;

        public bool CanIncrease => _index < EnemyManager.Instance.Count;

        private void OnEnable()
        {
            GetRandomMaxTime();
        }

        private void Update()
        {
            _currentSpawnTime += Time.deltaTime;
            
            if (_currentSpawnTime > _maxSpawnTime)
            {
                Spawn();
            }
            
            if (!CanIncrease) return;

            if (_maxAddEnemyTime < Time.time)
            {
                _maxAddEnemyTime = Time.time + EnemyManager.Instance.AddDelayTime;
                IncreaseIndex();
            }
        }

        private void Spawn()
        {
            EnemyController newEnemy = EnemyManager.Instance.GetPool((EnemyEnum)Random.Range(0, _index));
            newEnemy.transform.parent = this.transform;
            newEnemy.transform.position = this.transform.position;
            newEnemy.gameObject.SetActive(true);
            
            _currentSpawnTime = 0f;
            GetRandomMaxTime();
            
        }

        private void GetRandomMaxTime()
        {
            _maxSpawnTime = Random.Range(min, max);
        }
        
        private void IncreaseIndex()
        {
            if (CanIncrease)
            {
                _index++;
            }
        }
    }
}
