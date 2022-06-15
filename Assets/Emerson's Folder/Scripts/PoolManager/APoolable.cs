using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class APoolable : MonoBehaviour
{
    //initializes the property of this object.
    public abstract void initialize();

    //throws this event when this object has been released back to the pool.
    public abstract void onRelease(StructHandler.OnReleaseStruct info);

    //throws this event when this object has been activated from the pool.
    public abstract void onActivate(StructHandler.OnRequestStruct info);

    // creates a copy of the gameObject
    public abstract GameObject createCopy(ObjectPool pool);

    //provides a copy of the poolable instance. must be implemented per specific class
    public ObjectPool poolRef;
    // APoolable Overrides
    [SerializeField] private PoolType poolType;
    public PoolType PoolType
    {
        get { return this.poolType; }
    }
}