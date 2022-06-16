using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public Dictionary<PokeballCode, int> pokeballs;
    
    //constructor
    public Inventory()
    {
        // initialize dictionary
        pokeballs = new Dictionary<PokeballCode, int>();
        foreach (var i in Enum.GetValues(typeof(PokeballCode)))
        {
            pokeballs.Add((PokeballCode)i, 99);
        }
    }

    public void addPokeball(PokeballCode pokeballCode, int amount)
    {
        this.pokeballs[pokeballCode] += amount;

        if (this.pokeballs[pokeballCode] >= 99)
            this.pokeballs[pokeballCode] = 99;
    }

    public void removePokeball(PokeballCode pokeballCode, int amount)
    {
        this.pokeballs[pokeballCode] -= amount;

        if (this.pokeballs[pokeballCode] <= 0)
            this.pokeballs[pokeballCode] = 0;
    }

    public int getRemainingPokeball(PokeballCode pokeballCode)
    {
        return this.pokeballs[pokeballCode];
    }
}
