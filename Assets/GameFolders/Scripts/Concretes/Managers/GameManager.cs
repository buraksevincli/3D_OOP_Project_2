using System.Collections;
using GameFolders.Scripts.Abstracts.Utilities;
using GameFolders.Scripts.Concretes.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class GameManager : SingletonMonoBehaviourObject<GameManager>
    {
        [SerializeField] public LevelDifficultyData[] levelDifficultyDatas;
        public event System.Action OnGameStop;

        public LevelDifficultyData LevelDifficultyData => levelDifficultyDatas[0];
        
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
