using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionPanel : MonoBehaviour
{
    public List<Sprite> pokemonImage;

    [SerializeField]
    private List<GameObject> buttonsList;


    private List<GameObject> activeButtons;

    private MainPlayer mainPlayerRef;

    void Start()
    {
        mainPlayerRef = GameManager.Instance.mainPlayerRef;

        //pokemonImage = new List<Sprite>();
        //buttonsList = new List<GameObject>();
        activeButtons = new List<GameObject>();
    }

    public void activateButtons()
    {
        if(GameManager.Instance.mainPlayerRef.pokemonParty.Count != 0)
        {
            for (int i = 0; i < GameManager.Instance.mainPlayerRef.pokemonParty.Count; i++)
            {
                var i1 = i;
                buttonsList[i1].SetActive(true);
                buttonsList[i1].GetComponent<Image>().sprite = pokemonImage[
                    (int)GameManager.Instance.mainPlayerRef.pokemonParty[i1].pokemonCode];
                Debug.Log((int)GameManager.Instance.mainPlayerRef.pokemonParty[i1].pokemonCode);
                buttonsList[i1].GetComponent<Button>().onClick.AddListener(() => 
                    GameManager.Instance.panelController.PokemonInfo(
                        (int)GameManager.Instance.mainPlayerRef.pokemonParty[i1].pokemonCode));

                    //activeButtons.Add(buttonsList[i1]);
            }

            //setPokemon();
        }
    }

    public void setPokemon()
    {
        for (int i = 0; i < activeButtons.Count; i++)
        {
            activeButtons[i].GetComponent<Image>().sprite = pokemonImage[(int)GameManager.Instance.mainPlayerRef.pokemonParty[i].pokemonCode];
            activeButtons[i].GetComponent<Button>().onClick.AddListener(() => GameManager.Instance.panelController.PokemonInfo((int)GameManager.Instance.mainPlayerRef.pokemonParty[i].pokemonCode));
        }
    }
}
