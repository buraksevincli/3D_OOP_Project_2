using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.UIs
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] private GameOverPanel gameOverPanel;

        private void Awake()
        {
            gameOverPanel.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameStop += HandleOnGameStop;
        }
        
        private void OnDisable()
        {
            GameManager.Instance.OnGameStop -= HandleOnGameStop;
        }
        
        private void HandleOnGameStop()
        {
            gameOverPanel.gameObject.SetActive(true);
        }
    }
}
