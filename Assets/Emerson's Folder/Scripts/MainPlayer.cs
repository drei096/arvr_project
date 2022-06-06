using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer
{
    public string name;
    public List<PokemonCode> pokemonParty;
    public Inventory inventory;

    //constructor
    public MainPlayer()
    {
        // initialize fields
        pokemonParty = new List<PokemonCode>();
        inventory = new Inventory();
    }
}
