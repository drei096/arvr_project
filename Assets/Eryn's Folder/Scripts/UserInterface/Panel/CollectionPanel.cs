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
        if(mainPlayerRef.pokemonParty.Count != 0)
        {
            for (int i = 0; i < mainPlayerRef.pokemonParty.Count; i++)
            {
                if (buttonsList[i].activeSelf == false)
                {
                    buttonsList[i].SetActive(true);
                    activeButtons.Add(buttonsList[i]);
                }
            }

            setPokemon();
        }
    }

    public void setPokemon()
    {
        for (int i = 0; i < activeButtons.Count; i++)
        {
            activeButtons[i].GetComponent<Image>().sprite = pokemonImage[(int)mainPlayerRef.pokemonParty[i].pokemonCode];
            activeButtons[i].GetComponent<Button>().onClick.AddListener(() => GameManager.Instance.panelController.PokemonInfo((int)mainPlayerRef.pokemonParty[i].pokemonCode));
        }
    }
}
