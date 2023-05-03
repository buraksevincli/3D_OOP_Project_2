using GameFolders.Scripts.Concretes.Managers;
using GameFolders.Scripts.Concretes.ScriptableObjects;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class LevelInitializerController : MonoBehaviour
    {
        private LevelDifficultyData _levelDifficultyData;

        private void Awake()
        {
            _levelDifficultyData = GameManager.Instance.LevelDifficultyData;
        }

        private void Start()
        {
            RenderSettings.skybox = _levelDifficultyData.SkyboxMaterial;
            Instantiate(_levelDifficultyData.FloorPrefab);
            Instantiate(_levelDifficultyData.SpawnersPrefab);
        }
    }
}

