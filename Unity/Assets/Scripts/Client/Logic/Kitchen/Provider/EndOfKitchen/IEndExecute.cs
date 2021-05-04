using System.Collections;
using System.Collections.Generic;
using Kitchen.Enum;
using UnityEngine;

public interface IEndExecute
{
    void Execute(KitchenEndState state,CauseFailCode failCode = CauseFailCode.None);
}