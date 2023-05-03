using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] private EnemyController enemyPrefab;
        
        [Range(0.1f,5f)]
        [SerializeField] private float min = 0.1f;
        [Range(6f,15f)]
        [SerializeField] private float max = 15f;

        private float _maxSpawnTime;
        private float _currentSpawnTime = 0f;

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
        }

        private void Spawn()
        {
            EnemyController enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);

            enemy.transform.parent = this.transform;
            
            _currentSpawnTime = 0f;
            GetRandomMaxTime();
            
        }

        private void GetRandomMaxTime()
        {
            _maxSpawnTime = Random.Range(min, max);
        }
    }
}
