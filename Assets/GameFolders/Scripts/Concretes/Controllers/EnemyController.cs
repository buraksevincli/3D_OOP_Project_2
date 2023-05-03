using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using GameFolders.Scripts.Concretes.Movements;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float maxLifeTime = 10f;

        public float MoveSpeed => moveSpeed;
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
            Destroy(this.gameObject);
        }
    }
}

