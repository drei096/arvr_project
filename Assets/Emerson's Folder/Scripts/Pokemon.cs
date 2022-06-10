using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon : APoolable
{
    // Pokemon Info; editable
    public StructHandler.PokemonInfo info;
    public PokemonCode pokemonCode;
    public int exp;
    public int level;

    public override void initialize()
    {
        this.transform.SetParent(this.poolRef.poolableLocation);
        info = Pokedex.Instance.pokemonInfo[pokemonCode];
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
