using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolType : ScriptableObject
{
    [HideInInspector]
    public PoolManager sharedInstance;
    public GameObject objectToPool;
    public int poolCountLimit;

    [HideInInspector]
    public int activeCount;
}
