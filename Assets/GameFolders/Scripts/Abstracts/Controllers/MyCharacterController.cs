using UnityEngine;

namespace GameFolders.Scripts.Abstracts.Controllers
{
    public abstract class MyCharacterController : MonoBehaviour
    {
        [SerializeField] private float moveBoundary;
        [SerializeField] private float moveSpeed;
        
        public float MoveSpeed => moveSpeed;
        public float MoveBoundary => moveBoundary;
    }
}
