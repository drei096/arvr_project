using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StructHandler
{ 
    public struct OnRequestStruct
{
    public Transform parent;
    public Vector3 position;
}
public struct OnReleaseStruct
{
    public Transform parent;
    public Vector3 position;
}
    
public class MoveInfo
{
    public string name;
    public string description;
    public string type;
    public TypeCode typeCode;
    public int damage;

    public DelegateMove PerformMove;
    public DelegateMoveSound PerformMoveSound;
    public object ShallowCopy()
    {
        return this.MemberwiseClone();
    }
}

public class PokemonInfo
{
    public string name;
    public string description;
    public PokemonCode pokemonCode;
    public string type;
    public TypeCode typeCode;
    public int healthPoints;
    public MoveInfo move1;
    public MoveInfo move2;
    public DelegateCrySound PerformCrySound;

    public void SetHealth(int damage)
    {
        healthPoints -= damage;
    }

    public object ShallowCopy()
    {
        return this.MemberwiseClone();
    }
}

public class TrainerInfo
{
    public string name;
    public string description;
    public TrainerCode trainerCode;
    public List<StructHandler.PokemonInfo> pokemonParty;
}

public delegate void DelegateMove(ref List<PokemonInfo> y, int index);
public delegate void DelegateMoveSound();
public delegate void DelegateCrySound();
    
public class PokeballInfo
{
    public string name;
    public string description;
    public PokeballCode pokeballCode;
    public float successRate;
    public TypeCode typeSpecialty;
    public void CalculateSuccessRate()
    {
    }
}

}
