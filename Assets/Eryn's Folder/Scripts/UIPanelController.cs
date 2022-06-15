using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelController : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject mainOptionsPanel;
    public GameObject pokedexPanel;
    public GameObject pokemonPanel;
    public GameObject settingsPanel;

    public GameObject encounterPanel;
    public GameObject battlePanel;

    public InfoPanelController info;

    int previousPanelIndex;

    List<GameObject> panelOrder = new List<GameObject>();

    void Start()
    {
        panelOrder.Add(mainPanel);
        panelOrder.Add(mainOptionsPanel);
        panelOrder.Add(pokedexPanel);
        panelOrder.Add(pokemonPanel);
        panelOrder.Add(settingsPanel);
        panelOrder.Add(encounterPanel);
        panelOrder.Add(battlePanel);

        info = pokemonPanel.GetComponent<InfoPanelController>();

        Debug.Log(panelOrder.Count);
    }

    //sets all to inactive
    void setAllInactive()
    {
        for (int i = 0; i < panelOrder.Count; i++)
            panelOrder[i].SetActive(false);
    }

    //for main panel to extra main menu options
    public void mainOptionsActive()
    {
        previousPanelIndex = 0;
        mainOptionsPanel.SetActive(true);
        Debug.Log(previousPanelIndex);
    }

    //for extra main menu options to main panel
    public void mainOptionsInactive()
    {
        previousPanelIndex = 1;
        mainOptionsPanel.SetActive(false);
        Debug.Log(previousPanelIndex);
    }

    //for pokedex and pokemon info
    public void setActive(GameObject obj)
    {
        setAllInactive();
        previousPanelIndex = FindIndex(obj) - 1;
        panelOrder[previousPanelIndex + 1].SetActive(true);
        Debug.Log(previousPanelIndex);
    }

    //for pokedex and pokemon info
    public void setInactive(GameObject obj)
    {
        setAllInactive();
        previousPanelIndex = FindIndex(obj);
        obj.SetActive(false);
        if (previousPanelIndex - 1 == 1)
            panelOrder[0].SetActive(true);
        else
            panelOrder[previousPanelIndex - 1].SetActive(true);


        Debug.Log(previousPanelIndex);
    }

    //for settings
    public void openSettings()
    {
        settingsPanel.SetActive(true);
    }

    //for settings
    public void closeSettings()
    {
        settingsPanel.SetActive(false);
    }

    //for pokemon info
    public void openPokemonInfo(int pokemonCode)
    {
        PokemonCode code = (PokemonCode)pokemonCode;
        info.setInfo(code);
        info.pokemonImage.sprite = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
        setActive(pokemonPanel);
    }

    public void Encounter()
    {
        setAllInactive();
        encounterPanel.SetActive(true);
    }

    public void Battle()
    {
        setAllInactive();
        battlePanel.SetActive(true);
    }

    public void ReturnToMenu()
    {
        setAllInactive();
        mainPanel.SetActive(true);
    }

    //for finding index of previous panel opened
    int FindIndex(GameObject obj)
    {
        for (int i = 0; i < panelOrder.Count; i++)
        {
            if (panelOrder[i].name == obj.name)
                return i;
        }

        return 0;
    }
}
