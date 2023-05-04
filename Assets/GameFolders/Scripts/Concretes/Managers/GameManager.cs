using System.Collections;
using GameFolders.Scripts.Abstracts.Utilities;
using GameFolders.Scripts.Concretes.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class GameManager : SingletonMonoBehaviourObject<GameManager>
    {
        [SerializeField] private LevelDifficultyData[] levelDifficultyData;
        public event System.Action OnGameStop;

        public LevelDifficultyData LevelDifficultyData => levelDifficultyData[DifficultyIndex];

        private int _difficultyIndex;

        public int DifficultyIndex
        {
            get => _difficultyIndex;
            set
            {
                if (_difficultyIndex < 0 || _difficultyIndex > levelDifficultyData.Length)
                {
                    LoadSceneAsync("Menu");
                }
                else
                {
                    _difficultyIndex = value;
                }
            }
        }
        
        private void Awake()
        {
            SingletonThisGameObject(this);
        }

        public void StopGame()
        {
            Time.timeScale = 0f;

            OnGameStop?.Invoke();
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            Time.timeScale = 1f;
            yield return SceneManager.LoadSceneAsync(sceneName);
        }

        public void ExitGame()
        {
            Debug.Log("Exit");
            Application.Quit();
        }
    }
}
