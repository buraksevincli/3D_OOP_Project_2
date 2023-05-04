using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.UIs
{
    public class MenuPanel : MonoBehaviour
    {
        public void SelectAndStartButton(int index)
        {
            GameManager.Instance.DifficultyIndex = index;
            GameManager.Instance.LoadScene("Game");
        }
        public void ExitButton()
        {
            GameManager.Instance.ExitGame();
        }
    }
}
