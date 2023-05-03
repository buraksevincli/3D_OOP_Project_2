using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class FloorController : MonoBehaviour
    {
        [Range(2f, 5f)]
        [SerializeField] private float moveSpeed = 2f;
        
        private Material _material;

        private void Awake()
        {
            _material = GetComponentInChildren<MeshRenderer>().material;
        }

        private void Update()
        {
            _material.mainTextureOffset += Vector2.down * (Time.deltaTime * moveSpeed);
        }
    }
}

