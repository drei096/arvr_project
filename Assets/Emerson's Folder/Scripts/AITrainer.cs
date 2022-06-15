using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AITrainer : APoolable
{
    public StructHandler.TrainerInfo trainerInfo;
    public TrainerCode trainerCode;

    public void ResetPokemonParty()
    {
        // remove all pokemon elements
        trainerInfo.pokemonParty = new List<StructHandler.PokemonInfo>();
    }
    public void RandomPokemonParty()
    {
        for (int i = 0; i < GameManager.MAX_PARTY_SIZE; i++)
        {
            int pokemonMaxSize = Enum.GetValues(typeof(PokemonCode)).Length;
            int chosenPokemon = Random.Range(0, pokemonMaxSize - 1);
            StructHandler.PokemonInfo temp = 
                (StructHandler.PokemonInfo)Pokedex.Instance.pokemonInfo[(PokemonCode)chosenPokemon].ShallowCopy();
            trainerInfo.pokemonParty.Add(temp);
        }
    }
    public override void initialize()
    {
        this.transform.SetParent(this.poolRef.poolableLocation);
        trainerInfo = Pokedex.Instance.trainerInfo[trainerCode];
    }
    
    public override void onRelease(StructHandler.OnReleaseStruct info)
    {
        // returns the pool object to its original parent and position
        transform.SetParent(GameObject.FindGameObjectWithTag("PoolManager").transform);
        transform.position = GameObject.FindGameObjectWithTag("PoolManager").transform.position;
        // reset pokemon party
        ResetPokemonParty();
    }

    public override void onActivate(StructHandler.OnRequestStruct info)
    {
        // place the pool object to the specified position and parent
        transform.SetParent(info.parent);
        transform.position = info.position;
        // create a pokemon party for the opponent
        RandomPokemonParty();
        //temporary first pokemon is pikachu
        int pokemonMaxSize = Enum.GetValues(typeof(PokemonCode)).Length;
        int chosenPokemon = Random.Range(0, pokemonMaxSize - 1);
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
