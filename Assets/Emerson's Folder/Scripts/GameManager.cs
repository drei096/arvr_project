using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;
using Random = UnityEngine.Random;

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

    //POOL MANAGER REFERENCES
    private GameObject scriptsHolder;
    private GameObject poolManager;
    private PokemonPool pokemonPool;
    private TrainerPool trainerPool;
    private PokeballPool pokeballPool;
    [HideInInspector] public GameObject placedPokemon;
    private GameObject placedTrainer;

    // attribute fields
    public MainPlayer mainPlayerRef = null;

    // other scripts
    private GameObjectHandler GOHandler;
    private BattleSystem battleSystem;
    public UIPanelController panelController;
    public UIAnimController animController;

    // encounter checker
    private bool isEncounter = false;

    //CONSTRUCTOR
    private GameManager()
    {
        poolManager = GameObject.Find("PoolManager");
        pokemonPool = poolManager.GetComponent<PokemonPool>();
        trainerPool = poolManager.GetComponent<TrainerPool>();
        pokeballPool = poolManager.GetComponent<PokeballPool>();
        scriptsHolder = GameObject.FindGameObjectWithTag("ScriptsHolder");
        GOHandler = scriptsHolder.GetComponent<GameObjectHandler>();
        mainPlayerRef = new MainPlayer();
        battleSystem = GameObject.Find("Scripts").GetComponent<BattleSystem>();
        panelController = scriptsHolder.GetComponent<UIPanelController>();
        animController = scriptsHolder.GetComponent<UIAnimController>();
    }

    public void Encounter(MonoBehaviour mono)
    {
        GOHandler.planeFinder.SetActive(false);
        //GOHandler = GameObject.FindGameObjectWithTag("ScriptsHolder").GetComponent<GameObjectHandler>();

        // if the mainPlayer does not have a pokemon yet, then no trainer encounter first
        if (mainPlayerRef.pokemonParty.Count < 1)
        {
            encounterChooser = 1;
        }
        else
        {
            encounterChooser = Random.Range(1, 3);
        }
        
        if (encounterChooser == 1)
        {
            encounterType = EncounterType.POKEMON_ENCOUNTER;

            //SPAWN MODEL OF POKEMON HERE
            placedPokemon = pokemonPool.itemPool.RequestPoolable(pokemonSpawnRandomizer(), 
                new StructHandler.OnRequestStruct() {parent = GOHandler.opPokemonPos.transform, 
                    position = GOHandler.opPokemonPos.transform.position} );

            Debug.Log("encounter called");

            //CALL FUNCTION FOR POKEMON ENCOUNTERS
            pokemonEncounter(mono);

        }
        else if (encounterChooser == 2)
        {
            encounterType = EncounterType.TRAINER_ENCOUNTER;

            //SPAWN TRAINER MODEL HERE
            placedTrainer = trainerPool.itemPool.RequestPoolable(trainerSpawnRandomizer(),
                new StructHandler.OnRequestStruct() {parent = GOHandler.opTrainerPos.transform,
                    position = GOHandler.opTrainerPos.transform.position} );

            //CALL FUNCTION FOR TRAINER BATTLE
            trainerEncounter();
        }
    }

    private void pokemonEncounter(MonoBehaviour mono)
    {
        mono.StartCoroutine(delayPokeballSpawn());
        
        panelController.Encounter();

        //add statement here that disables another encounter after this current one 
        //pokemonPool.itemPool.ReleasePoolable(placedPokemon, new StructHandler.OnReleaseStruct() {parent = pokemonPool.transform, position = pokemonPool.transform.position} );

        //reset encounter type to NONE
        encounterType = EncounterType.NONE;
    }

    IEnumerator delayPokeballSpawn()
    {
        yield return new WaitForSeconds(5.0f);
        scriptsHolder.GetComponent<EncounterSystem>().requestPokeball(PokeballCode.GREATBALL);
    }

    private void trainerEncounter()
    {

        //add statement here that disables another encounter after this current one
        //trainerPool.itemPool.ReleasePoolable(placedTrainer, new StructHandler.OnReleaseStruct() {parent = trainerPool.transform, position = trainerPool.transform.position} );

        panelController.Battle();

        // starts the battle with the player
        battleSystem.StartBattle(GameManager.Instance.mainPlayerRef, placedTrainer.GetComponent<AITrainer>());

        //reset encounter type to NONE
        encounterType = EncounterType.NONE;

        //MAKE SURE TO SET StepCount.Instance.canCount to TRUE when the encounter is over
    }

    private PokemonCode pokemonSpawnRandomizer()
    {
        int pokemonMaxSize = Enum.GetValues(typeof(PokemonCode)).Length;
        int chosenPokemon = Random.Range(0, pokemonMaxSize - 1);
        return (PokemonCode) chosenPokemon;
    }

    private TrainerCode trainerSpawnRandomizer()
    {
        int trainerMaxSize = Enum.GetValues(typeof(TrainerCode)).Length;
        int chosenTrainerModel = Random.Range(0, trainerMaxSize - 1);
        return (TrainerCode) chosenTrainerModel;
    }

    public static void ResetGame()
    {

    }
}
