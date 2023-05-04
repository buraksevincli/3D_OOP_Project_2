using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.Controllers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Level Difficulty", menuName = "Create Difficulty/Create New", order = 1)]
    public class LevelDifficultyData : ScriptableObject
    {
        [SerializeField] private FloorController floorPrefab;
        [SerializeField] private GameObject spawnersPrefab;
        [SerializeField] private Material skyboxMaterial;
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _addDelayTime = 50f;

        public FloorController FloorPrefab => floorPrefab;
        public GameObject SpawnersPrefab => spawnersPrefab;
        public Material SkyboxMaterial => skyboxMaterial;
        public float MoveSpeed => _moveSpeed;
        public float AddDelayTime => _addDelayTime;
    }
}
