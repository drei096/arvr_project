using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer
{
    public string name;
    public List<StructHandler.PokemonInfo> pokemonParty;
    public Inventory inventory;

    //constructor
    public MainPlayer()
    {
        // initialize fields
        pokemonParty = new List<StructHandler.PokemonInfo>();
        // temporary first pokemon is pikachu
        StructHandler.PokemonInfo temp = (StructHandler.PokemonInfo)Pokedex.Instance.pokemonInfo[PokemonCode.PIKACHU].ShallowCopy();
        pokemonParty.Add(temp);
        inventory = new Inventory();
        Debug.LogError($"Initialize!");
    }
}
