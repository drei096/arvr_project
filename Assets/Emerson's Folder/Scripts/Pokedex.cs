using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Pokedex
{
    // Singleton
    private static Pokedex instance = null;

    public static Pokedex Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Pokedex();
                instance.Initialize();
            }
            return instance;
        }
    }
    // Logs whether the main player already caught the pokemon
    public Dictionary<PokemonCode, bool> caughtPokemon;
    // Pokemon and its corresponding info
    public Dictionary<PokemonCode, StructHandler.PokemonInfo> pokemonInfo;
    // Pokeball and its corresponding info
    public Dictionary<PokeballCode, StructHandler.PokeballInfo> pokeballInfo;
    // Move and its corresponding info
    public Dictionary<MoveCode, StructHandler.MoveInfo> moveInfo;
    // Trainer and its corresponding info
    public Dictionary<TrainerCode, StructHandler.TrainerInfo> trainerInfo;

    private void Initialize()
    {
        Debug.LogError($"Test");
        // initialize dictionary
        caughtPokemon = new Dictionary<PokemonCode, bool>();
        pokemonInfo = new Dictionary<PokemonCode, StructHandler.PokemonInfo>();
        pokeballInfo = new Dictionary<PokeballCode, StructHandler.PokeballInfo>();
        moveInfo = new Dictionary<MoveCode, StructHandler.MoveInfo>();
        trainerInfo = new Dictionary<TrainerCode, StructHandler.TrainerInfo>();

        foreach (var i in Enum.GetValues(typeof(PokemonCode)))
        {
            if ((PokemonCode)i != PokemonCode.NONE)
                caughtPokemon.Add((PokemonCode)i, false);
        }
        EnumsHandler.AddMoveData(ref moveInfo);
        EnumsHandler.AddPokemonData(ref pokemonInfo);
        EnumsHandler.AddPokeballData(ref pokeballInfo);
        EnumsHandler.AddTrainerData(ref trainerInfo);
    }
    public static void ShowPokedex()
    {

    }
    public static void UpdatePokedex()
    {

    }
}
