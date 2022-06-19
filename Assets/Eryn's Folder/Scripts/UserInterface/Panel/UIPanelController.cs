using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIPanelController : MonoBehaviour
{
    [Header("Main Panels")]
    //main panels
    public GameObject mainPanel;
    public GameObject mainOptionsPanel;
    public GameObject pokedexPanel;
    public GameObject pokemonPanel;
    public GameObject pokemonCollectionPanel;
    public GameObject settingsPanel;

    [Space]

    [Header("Encounter Panels")]
    //encounter panels
    public GameObject encounterPanel;
    public GameObject battlePanel;
    public GameObject StartEncounter;
    public GameObject StartBattle;

    [Space]

    //pokemon encounter panels (Extras)
    [Header("Pokemon Encounter Panels")]
    public GameObject catchPanel;
    public GameObject pokeballInventory;

    [Space]

    [HideInInspector]
    public InfoPanelController info;
    public CollectionPanel collection;

    [Header("Text UI")]
    public Text remainingPokeball;
    public Text PLPokemonName;
    public Slider PLPokemonHealth;
    public Text OPPokemonName;
    public Slider OPPokemonHealth;

    int previousPanelIndex;


    List<GameObject> panelOrder = new List<GameObject>();

    public delegate void pokemonInfo(int pokemonCode);

    public pokemonInfo PokemonInfo;

    void Start()
    {
        panelOrder.Add(mainPanel);
        panelOrder.Add(mainOptionsPanel);
        panelOrder.Add(pokedexPanel);
        panelOrder.Add(pokemonPanel);
        panelOrder.Add(pokemonCollectionPanel);
        panelOrder.Add(settingsPanel);
        panelOrder.Add(encounterPanel);
        panelOrder.Add(battlePanel);

        info = pokemonPanel.GetComponent<InfoPanelController>();
        collection = pokemonCollectionPanel.GetComponent<CollectionPanel>();

        Debug.Log(panelOrder.Count);

        this.PokemonInfo += delegate (int pokemonCode)
        {
            openPokemonInfo(pokemonCode);
        };
    }

    void Update()
    {
        remainingPokeball.text = GameManager.Instance.mainPlayerRef.inventory.getRemainingPokeball(this.gameObject.GetComponent<EncounterSystem>().CurrentPokeballCode).ToString();
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
        AudioManager.Instance.Play(SoundCode.SFX_UI_CLICK);

        previousPanelIndex = 1;
        mainOptionsPanel.SetActive(false);
        Debug.Log(previousPanelIndex);
    }

    //for pokedex and pokemon info
    public void setActive(GameObject obj)
    {
        AudioManager.Instance.Play(SoundCode.SFX_UI_CLICK);

        setAllInactive();
        previousPanelIndex = FindIndex(obj) - 1;
        panelOrder[previousPanelIndex + 1].SetActive(true);
        Debug.Log(previousPanelIndex);
    }

    //for pokedex and pokemon info
    public void setInactive(GameObject obj)
    {
        AudioManager.Instance.Play(SoundCode.SFX_UI_CLICK);

        setAllInactive();
        if (previousPanelIndex == 3)
            panelOrder[0].SetActive(true);
        else if(previousPanelIndex == 2 || previousPanelIndex == 4)
            panelOrder[previousPanelIndex].SetActive(true);

        previousPanelIndex = FindIndex(obj);


        Debug.Log(previousPanelIndex);
    }

    //for settings
    public void openSettings()
    {
        AudioManager.Instance.Play(SoundCode.SFX_MENU_ACCESS);
        settingsPanel.SetActive(true);
    }

    //for settings
    public void closeSettings()
    {
        AudioManager.Instance.Play(SoundCode.SFX_UI_CLICK);
        settingsPanel.SetActive(false);
    }

    //for pokemon info
    public void openPokemonInfo(int pokemonCode)
    {
        AudioManager.Instance.Play(SoundCode.SFX_UI_CLICK);

        PokemonCode code = (PokemonCode)pokemonCode;
        info.setInfo(code);
        info.pokemonImage.sprite = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
        setActive(pokemonPanel);
    }

    public void openCollection()
    {
        AudioManager.Instance.Play(SoundCode.SFX_UI_CLICK); 
        previousPanelIndex = FindIndex(pokemonCollectionPanel);

        setActive(pokemonCollectionPanel);
        collection.activateButtons();
    }

    public void Menu()
    {
        AudioManager.Instance.Play(SoundCode.SFX_UI_CLICK);
        setAllInactive();
        mainPanel.SetActive(true);
    }

    public void Encounter()
    {
        setAllInactive();
        encounterPanel.SetActive(true);
        StartEncounter.SetActive(true);
        GameManager.Instance.animController.triggerAnim(GameManager.Instance.animController.startEncounter);
    }

    public void Battle()
    {
        setAllInactive();
        battlePanel.SetActive(true);
        StartBattle.SetActive(true);
        GameManager.Instance.animController.triggerAnim(GameManager.Instance.animController.battleStart);
    }

    public void ReturnToMenu()
    {
        // only for CatchPokemonPanel UI; hides the panel after clicking 'okay'
        if (UnityEngine.EventSystems.EventSystem.current.
                currentSelectedGameObject.transform.parent.parent.gameObject.tag == "CatchPokemonPanel")
        {
            UnityEngine.EventSystems.EventSystem.current.
                currentSelectedGameObject.transform.parent.parent.gameObject.SetActive(false);
        }
        setAllInactive();

        //DISABLE VICTORY MUSIC, GO BACK TO EXPLORING MUSIC
        AudioManager.Instance.Stop(SoundCode.BGM_VICTORY);
        AudioManager.Instance.Stop(SoundCode.BGM_ENCOUNTER_START);
        AudioManager.Instance.Play(SoundCode.BGM_EXPLORING);

        mainPanel.SetActive(true);
    }

    public void setUIPanelInactive(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void setUIPanelActive(GameObject panel)
    {
        panel.SetActive(true);
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

    public void sliderAssign(Slider slider, int health, int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = health;
    }
}
