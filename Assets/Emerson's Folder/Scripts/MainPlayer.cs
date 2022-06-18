using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer
{
    public string name;
    public List<StructHandler.PokemonInfo> pokemonParty;
    public List<StructHandler.PokemonInfo> pokemonInventory;
    public Inventory inventory;

    //constructor
    public MainPlayer()
    {
        // initialize fields
        pokemonParty = new List<StructHandler.PokemonInfo>();
        pokemonInventory = new List<StructHandler.PokemonInfo>();
        /*
        // temporary first pokemon is pikachu
        StructHandler.PokemonInfo temp = (StructHandler.PokemonInfo)Pokedex.Instance.pokemonInfo[PokemonCode.PIKACHU].ShallowCopy();
        pokemonParty.Add(temp);
        */
        inventory = new Inventory();
        Debug.LogError($"Initialize!");
    }

    public void RestorePartyHealth()
    {
        // Reset the health of each pokemon in the player's party
        for (int i = 0; i < pokemonParty.Count; i++)
        {
            pokemonParty[i] = (StructHandler.PokemonInfo)Pokedex.Instance.pokemonInfo[pokemonParty[i].pokemonCode].ShallowCopy();
        }
    }

    public void AddPokemonToParty(PokemonCode code)
    {
        // Check if there is still a slot in the pokemonParty
        if (pokemonParty.Count < GameManager.MAX_PARTY_SIZE)
        {
            StructHandler.PokemonInfo temp = (StructHandler.PokemonInfo)Pokedex.Instance.pokemonInfo[code].ShallowCopy();
            pokemonParty.Add(temp);
        }
    }
}
