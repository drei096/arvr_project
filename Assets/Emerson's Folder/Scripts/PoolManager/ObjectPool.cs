using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class ObjectPool
{
    //transform location of the poolStorage and spawn locations
    public Transform poolableLocation;
    private List<Transform> spawnLocations = new List<Transform>();

    //max size of the pool and if its size isDynamic
    private int maxPoolSize = 20; //default
    private bool fixedAllocation = true; //default

    //collection of the available and used objects currently in the game
    public List<GameObject> availableObjects = new List<GameObject>();
    public List<GameObject> usedObjects = new List<GameObject>();

    //spawnerType
    private PoolType poolType;
    //spawnerType
    public PoolType PoolType
    {
        get { return this.poolType; }
        private set { poolType = value; }
    }

    private IPoolFunctions poolFunctions;

    //constructor; even though the parameters have default values, it is necessary to assign a value to it in your instantiation
    public ObjectPool(int maxPoolSize = 20, bool fixedAllocation = true, List<Transform> spawnLocations = null, 
        PoolType poolType = PoolType.NONE, IPoolFunctions poolFunc = null)
    {
        if(spawnLocations != null)
        {
            this.maxPoolSize = maxPoolSize;
            this.fixedAllocation = fixedAllocation;
            this.spawnLocations = spawnLocations;
            this.PoolType = poolType;
            this.poolFunctions = poolFunc;
        }
        else
        {
            Debug.LogError("NO Spawn Locations Found for this Spawner!");
        }
    }

    public int MaxPoolSize
    {
        get { return maxPoolSize; }
    }

    //call this in the awake or start of every spawnType you've created
    public void Initialize<T>(ref List <GameObject> objs, Transform poolableLocation, T refSpawner)
    {
        this.poolableLocation = poolableLocation;
        int count = 0;
        for (int k = 0; k < objs.Count; k++)
        {
            APoolable copy = objs[k].GetComponent<APoolable>();
            for (int i = 0; i < MaxPoolSize; i++)
            {
                availableObjects.Add(copy.createCopy(this));
                if(typeof(T).Equals(typeof(PokemonCode)))
                {

                }
                else if(typeof(T).Equals(typeof(PokeballCode)))
                {

                }
                else if(typeof(T).Equals(typeof(TrainerCode)))
                {

                }
                availableObjects[count++].SetActive(false);
        }   }

    }

    //increase the maxSize of the pool
    public void increaseMaxPoolSize(int addSize)
    {
        if(!fixedAllocation)
        {
            maxPoolSize += addSize;
        }
        else
        {
            Debug.Log("Fixed Allocation is set to True!");
        }
    }

    public bool HasObjectAvailable(int size)
    {
        if (this.availableObjects.Count >= size && size > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public GameObject RequestPoolable(StructHandler.OnRequestStruct info)
    {
        usedObjects.Add(availableObjects[0]);
        availableObjects.RemoveAt(0);
        // calls the onActivate func of the poolable
        this.poolFunctions.onRequestGo(info);
        //poolable now exist in the game
        usedObjects[usedObjects.Count - 1].SetActive(true);

        return usedObjects[usedObjects.Count - 1];
    }
    public GameObject RequestPoolable(PokemonCode pokemonCode, StructHandler.OnRequestStruct info)
    {
        for (int i = 0; i < availableObjects.Count; i++)
        {
            // condition for the specific pokemonCode
            if(availableObjects[i].GetComponent<APoolable>().PoolType == PoolType.POKEMON && 
               availableObjects[i].GetComponent<Pokemon>().info.pokemonCode == pokemonCode)
            {
                usedObjects.Add(availableObjects[i]);
                availableObjects.RemoveAt(i);
                //poolable now exist in the game
                usedObjects[usedObjects.Count - 1].SetActive(true);
                //sets the onActivate func of the poolable
                this.poolFunctions.onRequestGo(info);

                return usedObjects[usedObjects.Count - 1];
            }
        }

        return null;
    }

    public GameObject RequestPoolable(PokeballCode pokeballCode, StructHandler.OnRequestStruct info)
    {
        for (int i = 0; i < availableObjects.Count; i++)
        {
            // condition for the specific pokeballCode
            if(availableObjects[i].GetComponent<APoolable>().PoolType == PoolType.POKEBALL && 
               availableObjects[i].GetComponent<Pokeball>().info.pokeballCode == pokeballCode)
            {
                usedObjects.Add(availableObjects[i]);
                availableObjects.RemoveAt(i);
                //poolable now exist in the game
                usedObjects[usedObjects.Count - 1].SetActive(true);
                //sets the onActivate func of the poolable
                this.poolFunctions.onRequestGo(info);

                return usedObjects[usedObjects.Count - 1];
            }
        }

        return null;
    }
    public GameObject RequestPoolable(TrainerCode trainerCode, StructHandler.OnRequestStruct info)
    {
        for (int i = 0; i < availableObjects.Count; i++)
        {
            // condition for the specific trainerCode
            if(availableObjects[i].GetComponent<APoolable>().PoolType == PoolType.TRAINER && 
               availableObjects[i].GetComponent<AITrainer>().trainerInfo.trainerCode == trainerCode)
            {
                usedObjects.Add(availableObjects[i]);
                availableObjects.RemoveAt(i);
                //poolable now exist in the game
                usedObjects[usedObjects.Count - 1].SetActive(true);
                //sets the onActivate func of the poolable
                this.poolFunctions.onRequestGo(info);

                return usedObjects[usedObjects.Count - 1];
            }
        }

        return null;
    }

    public void ReleasePoolable(int index, StructHandler.OnReleaseStruct info)
    {
        availableObjects.Add(usedObjects[index]);
        usedObjects.RemoveAt(index);
        availableObjects[availableObjects.Count - 1].transform.SetParent(this.poolableLocation);
        this.poolFunctions.onReleaseGo(info);
        availableObjects[availableObjects.Count - 1].SetActive(false);
    }
    public void ReleasePoolable(GameObject go, StructHandler.OnReleaseStruct info)
    {
        if(usedObjects.Contains(go) || go != null)
        {
            availableObjects.Add(go);
            usedObjects.Remove(go);
            availableObjects[availableObjects.Count - 1].transform.SetParent(this.poolableLocation);
            this.poolFunctions.onReleaseGo(info);
            availableObjects[availableObjects.Count - 1].SetActive(false);
        }
        else
        {
            //Debug.LogError($"Object doesn't exist in the list.");
        }
    }
}
