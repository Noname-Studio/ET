using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameAction
{
    void Execute();
    bool Update();
}
