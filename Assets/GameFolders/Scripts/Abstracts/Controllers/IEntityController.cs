using UnityEngine;

namespace GameFolders.Scripts.Abstracts.Controllers
{
    public interface IEntityController
    {
        Transform transform { get; }

        float MoveSpeed { get; }
        float MoveBoundary { get; }
    }

}