using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokedex
{
    // Singleton
    private static Pokedex instance = null;

    public static Pokedex Instance
    {
        get
        {
            if (instance == null)
                instance = new Pokedex();
            return instance;
        }
    }
    // Logs whether the main player already caught the pokemon
    public Dictionary<PokemonCode, bool> caughtPokemon;
    // Pokemon and its corresponding info
    public Dictionary<PokemonCode, PokemonInfo> pokemonInfo;
    // Pokeball and its corresponding info
    public Dictionary<PokeballCode, PokeballInfo> pokeballInfo;
    // Move and its corresponding info
    public Dictionary<MoveCode, MoveInfo> moveInfo;
    // Trainer and its corresponding info
    public Dictionary<TrainerCode, TrainerInfo> trainerInfo;
    
    //constructor
    private Pokedex()
    {
        // initialize dictionary
        caughtPokemon = new Dictionary<PokemonCode, bool>();
        pokemonInfo = new Dictionary<PokemonCode, PokemonInfo>();
        pokeballInfo = new Dictionary<PokeballCode, PokeballInfo>();
        foreach (var i in Enum.GetValues(typeof(PokemonCode)))
        {
            if ((PokemonCode)i != PokemonCode.NONE)
                caughtPokemon.Add((PokemonCode)i, false);
        }
        EnumsHandler.AddPokemonData(ref pokemonInfo);
        EnumsHandler.AddPokeballData(ref pokeballInfo);
        EnumsHandler.AddMoveData(ref moveInfo);
        EnumsHandler.AddTrainerData(ref trainerInfo);
    }

    public static void ShowPokedex()
    {

    }
    public static void UpdatePokedex()
    {

    }
}
