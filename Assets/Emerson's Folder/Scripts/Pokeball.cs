using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball : APoolable
{
    public PokeballInfo info;
    public PokeballCode pokeballCode;
    
    // APoolable Overrides
    [SerializeField] private PoolType poolType;
    public PoolType PoolType
    {
        get { return this.poolType; }
    }
    
    public override void initialize()
    {
        this.transform.SetParent(this.poolRef.poolableLocation);
    }

    public override void onRelease()
    {

    }

    public override void onActivate()
    {

    }

    public override GameObject createCopy(ObjectPool pool)
    {
        //duplicate the origin copy
        GameObject go = 
            GameObject.Instantiate(this.gameObject, this.transform.position, Quaternion.identity) as GameObject;

        //awake
        go.GetComponent<APoolable>().poolRef = pool;
        go.GetComponent<APoolable>().initialize();
        return go;
    }
}
