using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.UIs
{
    public class GameOverPanel : MonoBehaviour
    {
        public void RetryButton()
        {
            GameManager.Instance.LoadScene("Game");
        }

        public void MenuButton()
        {
            GameManager.Instance.LoadScene("Menu");
        }
    }
}
