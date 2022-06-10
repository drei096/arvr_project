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

    //FOR RANDOMIZER
    private float timer;
    private EncounterType encounterType;
    private int encounterChooser;

    //GROUND PLANE STAGE REFERENCE
    private GameObject groundPlaneGO;

    //POOL MANAGER REFERENCES
    private GameObject poolManager;
    private PokemonPool pokemonPool;
    private TrainerPool trainerPool;
    private PokeballPool pokeballPool;
    private GameObject placedPokemon;

    //CONSTRUCTOR
    private GameManager()
    {
        poolManager = GameObject.Find("PoolManager");
        pokemonPool = poolManager.GetComponent<PokemonPool>();
        trainerPool = poolManager.GetComponent<TrainerPool>();
        pokeballPool = poolManager.GetComponent<PokeballPool>();

    }

    public void Encounter()
    {
        groundPlaneGO = GameObject.FindGameObjectWithTag("GroundPlane");

        encounterChooser = Random.Range(1, 3);
        if (encounterChooser == 1)
        {
            encounterType = EncounterType.POKEMON_ENCOUNTER;

            //SPAWN MODEL OF POKEMON HERE
            placedPokemon = pokemonPool.itemPool.RequestPoolable(PokemonCode.PIKACHU, new StructHandler.OnRequestStruct() {parent = groundPlaneGO.transform, position = groundPlaneGO.transform.position} );

            //CALL FUNCTION FOR POKEMON ENCOUNTERS
            pokemonEncounter();

        }
        else if (encounterChooser == 2)
        {
            encounterType = EncounterType.TRAINER_ENCOUNTER;

            //SPAWN TRAINER MODEL HERE

            //CALL FUNCTION FOR TRAINER BATTLE
            trainerEncounter();
        }
    }

    private void pokemonEncounter()
    {
        
        
        //add statement here that disables another encounter after this current one 
        //pokemonPool.itemPool.ReleasePoolable(placedPokemon, new StructHandler.OnReleaseStruct() {parent = pokemonPool.transform, position = pokemonPool.transform.position} );

        //at the end, reenable step counter again
        StepCount.Instance.gameObject.SetActive(true);
    }

    private void trainerEncounter()
    {

        //add statement here that disables another encounter after this current one

        //at the end, reenable step counter again
        StepCount.Instance.gameObject.SetActive(true);
    }

    public static void ResetGame()
    {

    }
}
