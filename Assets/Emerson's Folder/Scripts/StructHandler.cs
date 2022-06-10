using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PokemonInfo
{
    public string name;
    public string description;
    public PokemonCode pokemonCode;
    public string type;
    public TypeCode typeCode;
    public int healthPoints;
    public MoveInfo? move1;
    public MoveInfo? move2;
    // Constructor
    public PokemonInfo(bool create = true)
    {
        // initialization
        name = "\0";
        description = "\0";
        pokemonCode = PokemonCode.NONE;
        type = "\0";
        typeCode = TypeCode.NONE;
        healthPoints = 0;
        move1 = null;
        move2 = null;
    }
    
}
public struct TrainerInfo
{
    public string name;
    public string description;
    public List<PokemonCode> pokemonParty;
    // Constructor
    public TrainerInfo(bool create = true)
    {
        // initialization
        pokemonParty = new List<PokemonCode>();
        name = "\0";
        description = "\0";
    }

}
public struct MoveInfo
{
    public string name;
    public string description;
    public string type;
    public TypeCode typeCode;
    public int damage;
    // Constructor
    public MoveInfo(bool create = true)
    {
        // initialization
        name = "\0";
        description = "\0";
        type = "\0";
        typeCode = TypeCode.NONE;
        damage = 0;
    }
    public void PerformMove(){}
}
public struct PokeballInfo
{
    public string name;
    public string description;
    public PokeballCode pokeballCode;
    public float successRate;
    public TypeCode typeSpecialty;
    // Constructor
    public PokeballInfo(bool create = true)
    {
        // initialization
        name = "\0";
        description = "\0";
        pokeballCode = PokeballCode.NONE;
        successRate = 0.0f;
        typeSpecialty = TypeCode.NONE;
    }

    public void CalculateSuccessRate()
    {
    }
}
public class StructHandler
{

}
