using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.Controllers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class HorizontalMover
    {
        private PlayerController _playerController;

        public HorizontalMover(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void TickFixed(float horizontal, float moveSpeed)
        {
            if(horizontal == 0f) return;
            
            _playerController.transform.Translate(Vector3.right * (horizontal * Time.deltaTime * moveSpeed));
        }
    }
}

