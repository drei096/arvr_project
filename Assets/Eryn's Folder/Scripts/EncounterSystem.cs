using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterSystem : MonoBehaviour
{
    //Main Player Reference
    private MainPlayer mainPlayer;
    //Inventory Shortcut reference
    private Inventory inventory;
    private GameObjectHandler GOHandler;

    private GameObject ballTemp;

    //current pokeball
    private PokeballCode currentPokeballCode;

    // Start is called before the first frame update
    void Start()
    {
        mainPlayer = GameManager.Instance.mainPlayerRef;
        inventory = mainPlayer.inventory;
        GOHandler = GameObject.FindGameObjectWithTag("ScriptsHolder").GetComponent<GameObjectHandler>();
        //GameManager.Instance.Encounter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void requestPokeball(PokeballCode pokeballCode)
    {
        currentPokeballCode = pokeballCode;

        Debug.Log("Request Pokeball!");
        ballTemp = GameObject.FindObjectOfType<PokeballPool>().itemPool.RequestPoolable(currentPokeballCode,
        new StructHandler.OnRequestStruct()
        {
            parent = GOHandler.pokeballPos.transform,
            position = GOHandler.pokeballPos.transform.position
    }) ;

        ballTemp.SendMessage("Reset");
    }

    public void switchPokeball(int pokeballCode)
    {
        PokeballCode toEnumCode = (PokeballCode) pokeballCode;
        releasePokeball();
        requestPokeball(toEnumCode);
    }

    private void releasePokeball()
    {
        Debug.Log("Release Pokeball!");
        GameObject.FindObjectOfType<PokeballPool>().itemPool.ReleasePoolable(ballTemp,
            new StructHandler.OnReleaseStruct()
            {
                parent = GOHandler.transform,
                position = Vector3.zero
            });
    }

    public void ThrownPokeball(PokeballCode pokeballCode)
    {
        releasePokeball();
        Debug.Log(inventory.getRemainingPokeball(pokeballCode));
    }

    public bool catchPokemon(PokeballCode pokeballCode)
    {
        ThrownPokeball(pokeballCode);

        float successRate = Pokedex.Instance.pokeballInfo[pokeballCode].successRate;
        float randomFloat = Random.Range(0, 10);

        if (randomFloat >= 10 * successRate)
            return false;
        else
            return true;
    }

    public void RunFromEncounter()
    {
        //RELEASE POKEMON POOLABLE OBJ
        GameObject.FindObjectOfType<PokemonPool>().itemPool.ReleasePoolable(GameManager.Instance.placedPokemon,
            new StructHandler.OnReleaseStruct()
            {
                parent = GOHandler.transform,
                position = Vector3.zero
            });

        //RELEASE POKEBALL POOLABLE OBJ
        releasePokeball();

        //ENABLE STEP COUNTER AGAIN
        StepCount.Instance.EnableCanCount();

        //TRIGGER A RUN PANEL?

        //REDIRECT BACK TO MAIN PANEL
        UI_Controller.Instance.triggerEncounterAnim(false);
        GameObject.FindGameObjectWithTag("ScriptsHolder").GetComponent<UIPanelController>().ReturnToMenu();

    }

    public PokeballCode CurrentPokeballCode
    {
        get { return currentPokeballCode; }
        set { currentPokeballCode = value; }
    }
}
