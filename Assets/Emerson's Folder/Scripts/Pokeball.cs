using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball : APoolable
{
    public StructHandler.PokeballInfo info;
    public PokeballCode pokeballCode;
    
    public override void initialize()
    {
        this.transform.SetParent(this.poolRef.poolableLocation);
        info = Pokedex.Instance.pokeballInfo[pokeballCode];
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
