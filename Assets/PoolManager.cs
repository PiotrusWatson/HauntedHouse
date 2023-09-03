using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    public Stack<GameObject> pooledObjects;
    public PoolType type;
    // Start is called before the first frame update
    void Awake()
    {
        type.sharedInstance = this;
        type.activeCount = 0;
    }

    // Update is called once per frame
    void Start()
    {
        pooledObjects = new Stack<GameObject>();
    }

    public GameObject GetPooledObject(){
        type.activeCount += 1;
        if (pooledObjects.Count > 0){
            return pooledObjects.Pop();
        }
        GameObject gameObj= Instantiate(type.objectToPool);
        gameObj.transform.parent = gameObject.transform;
        return gameObj;
    }

    public void AddToPool(GameObject gameObj){
        type.activeCount -= 1;
        pooledObjects.Push(gameObj);
    }
}
