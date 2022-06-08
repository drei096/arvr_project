using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//General Identification of the pool type
public enum PoolType
{
    NONE = -1,
    POKEMON,
    POKEBALL,
    TRAINER

};

public enum PokemonCode
{
    // Write here Pokemon Names
    NONE = -1,
    PIKACHU
};

public enum TypeCode
{
    // Write here Type Names
    NONE = -1,
    ELECTRIC,
    NORMAL
};

public enum PokeballCode
{
    // Write here Pokeball Names
    NONE = -1,
    GREATBALL
};

public enum MoveCode
{
    // Write here Move Names
    NONE = -1,
    THUNDER,
    QUICKATTACK
};

public enum TrainerCode
{
    // Write here Trainer Names
    NONE = -1,
    Joey
};

public enum EncounterType
{
    // Write here Trainer Names
    NONE = -1,
    POKEMON_ENCOUNTER,
    TRAINER_ENCOUNTER
};

public class EnumsHandler
{
    // Singleton
    private static EnumsHandler instance = null;

    public static EnumsHandler Instance
    {
        get
        {
            if (instance == null)
                instance = new EnumsHandler();
            return instance;
        }
    }
    // Write here the permanent data info
    public static void AddPokemonData(ref Dictionary<PokemonCode, PokemonInfo> pokemonInfo)
    {
        PokemonInfo temp = new PokemonInfo()
        {
            name = "Pickachu", pokemonCode = PokemonCode.PIKACHU, 
            type = "Electric", typeCode = TypeCode.ELECTRIC,
            healthPoints = 100, description = "Pika Pika chu chu",
            move1 = Pokedex.Instance.moveInfo[MoveCode.THUNDER],
            move2 = Pokedex.Instance.moveInfo[MoveCode.QUICKATTACK]
        };
        pokemonInfo.Add(PokemonCode.PIKACHU, temp);
    }
    // Write here the permanent data info
    public static void AddPokeballData(ref Dictionary<PokeballCode, PokeballInfo> pokeballInfo)
    {
        PokeballInfo temp = new PokeballInfo()
        {
            name = "Great Ball", pokeballCode = PokeballCode.GREATBALL, 
            successRate = 0.75f, typeSpecialty = TypeCode.NONE,
            description = "What a ball!"
        };
        pokeballInfo.Add(PokeballCode.GREATBALL, temp);
    }
    // Write here the permanent data info
    public static void AddMoveData(ref Dictionary<MoveCode, MoveInfo> moveInfo)
    {
        MoveInfo temp = new MoveInfo()
        {
            name = "Thunder", typeCode = TypeCode.ELECTRIC, 
            damage = 50, description = "Scary Thunder!!"
        };
        moveInfo.Add(MoveCode.THUNDER, temp);
        temp = new MoveInfo()
        {
            name = "Quick Attack", typeCode = TypeCode.NORMAL, 
            damage = 20, description = "Fast!!"
        };
        moveInfo.Add(MoveCode.QUICKATTACK, temp);
    }
    // Write here the permanent data info
    public static void AddTrainerData(ref Dictionary<TrainerCode, TrainerInfo> trainerInfo)
    {
        TrainerInfo temp = new TrainerInfo()
        {
            name = "Joey", description = "Normal Kid, very good!@"
        };
        trainerInfo.Add(TrainerCode.Joey, temp);
    }
}
