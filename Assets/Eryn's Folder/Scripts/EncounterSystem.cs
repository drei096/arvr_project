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
        Debug.Log("Request Pokeball!");
        ballTemp = GameObject.FindObjectOfType<PokeballPool>().itemPool.RequestPoolable(pokeballCode,
        new StructHandler.OnRequestStruct()
        {
            parent = GOHandler.pokeballPos.transform,
            position = GOHandler.pokeballPos.transform.position
    }) ;

        ballTemp.SendMessage("Reset");
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
        inventory.removePokeball(pokeballCode, 1);
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


}
