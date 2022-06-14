using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is an exmaple of our spawn type
public class PokeballPool : MonoBehaviour, IPoolFunctions
{
    //the type of pool and the originalObj; both are required, set you're preferred values for the constructors(maxSize, isFixAllocation?)
    [HideInInspector] public ObjectPool itemPool;
    public List<GameObject> originalObjs = new List<GameObject>();

    //transform location of the poolStorage and spawn locations
    private Transform poolableLocation;
    private List<Transform> spawnLocations = new List<Transform>();
    // pool original parent
    private Transform originalParent = null;

    //max size of the pool and if its size isDynamic
    [SerializeField] private int maxPoolSizePerObj = 20; //default
    [SerializeField] private bool fixedAllocation = true; //default

    void Start()
    {
        itemPool = new ObjectPool(this.maxPoolSizePerObj, this.fixedAllocation,
            this.spawnLocations, PoolType.POKEBALL, this.GetComponent<PokeballPool>());
        poolableLocation = this.transform;
        this.itemPool.Initialize(ref originalObjs, poolableLocation, this);
        originalParent = this.transform;
    }


    // Update is called once per frame
    void Update()
    {

    }
    

    //start of "IPoolFunctions" functions 
    //**
    public void onRequestGo(StructHandler.OnRequestStruct info)
    {
        // place the pool object to the specified position and parent
        this.itemPool.usedObjects[this.itemPool.usedObjects.Count - 1].transform.SetParent(info.parent);
        this.itemPool.usedObjects[this.itemPool.usedObjects.Count - 1].transform.position = info.position;
    }
    public void onReleaseGo(StructHandler.OnReleaseStruct info)
    {
        // returns the pool object to its original parent and position
        this.itemPool.usedObjects[this.itemPool.availableObjects.Count - 1].transform.SetParent(originalParent);
        this.itemPool.usedObjects[this.itemPool.availableObjects.Count - 1].transform.position = originalParent.position;
    }
    //**
    //end of "IPoolFunctions" functions 
}