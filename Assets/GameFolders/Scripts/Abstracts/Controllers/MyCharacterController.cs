using UnityEngine;

namespace GameFolders.Scripts.Abstracts.Controllers
{
    public abstract class MyCharacterController : MonoBehaviour
    {
        [SerializeField] private float _moveBoundary;
        [SerializeField] protected float _moveSpeed;
        
        public float MoveSpeed => _moveSpeed;
        public float MoveBoundary => _moveBoundary;
    }
}
