using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBContainerKey : Attribute
{
    public string PartKey { get; }
    public DBContainerKey(string partKey = "")
    {
        PartKey = partKey;
    }
}
