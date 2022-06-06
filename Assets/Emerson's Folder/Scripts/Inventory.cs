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
            pokeballs.Add((PokeballCode)i, 0);
        }
    }
}
