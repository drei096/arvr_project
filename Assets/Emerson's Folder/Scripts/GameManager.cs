using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    // Singleton
    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }
    }
    // GAME RULES
    public const int MAX_PARTY_SIZE = 6;
    public const int MAX_INVENTORY_SIZE = 100;

    public float timer;


    public void Encounter()
    {
        Debug.Log("trigger encounter here");
    }

    public static void ResetGame()
    {

    }
}
