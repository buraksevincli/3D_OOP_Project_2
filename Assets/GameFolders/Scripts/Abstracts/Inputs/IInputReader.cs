using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFolders.Scripts.Abstracts.Inputs
{
    public interface IInputReader
    {
        float Horizontal { get; }
        bool IsJump { get; }
    }
}

