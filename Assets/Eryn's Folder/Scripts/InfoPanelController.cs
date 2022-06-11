using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanelController : MonoBehaviour
{
    public Image pokemonImage;
    public Text pokemonName;
    public Text type1;
    public Text type2;
    public Text description;
    public Text move1;
    public Text move2;

    StructHandler.PokemonInfo temp;


    public void setInfo(PokemonCode pokemonCode)
    {
        temp = Pokedex.Instance.pokemonInfo[pokemonCode];

        pokemonName.text = temp.name;
        type1.text = temp.type;
        type2.text = "NONE";
        description.text = temp.description;
        move1.text = temp.move1.Value.name;
        move2.text = temp.move2.Value.name;
    }

}
