using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    // attribute fields
    private MainPlayer mainPlayer;
    private AITrainer opponent;
    private int playerCurrentPokemon = 0;
    private int opponentCurrentPokemon = 0;

    // buttons for the two move of the pokemon; assure that the size is 
    [SerializeField] private Button[] buttonsUI;
    [SerializeField] private Button AttackButton;

    void Start()
    {
        GameObjectHandler GOHandler = GameObject.FindGameObjectWithTag("ScriptsHolder").GetComponent<GameObjectHandler>();
        AttackButton.onClick.AddListener(AssignMoves);
        AttackButton.onClick.AddListener(() => Debug.LogError($"Click 'Attack'!"));
        // Temporary code
        AttackButton.onClick.AddListener(() =>
            StartBattle(GameManager.Instance.mainPlayerRef,
                    GameObject.FindObjectOfType<TrainerPool>().itemPool.RequestPoolable(TrainerCode.Joey,
                        new StructHandler.OnRequestStruct()
                        {
                            parent = GOHandler.opPokemonPos.transform,
                            position = GOHandler.opPokemonPos.transform.position
                        }).GetComponent<AITrainer>()
                )
        );
    }

    public void StartBattle(MainPlayer mainPl, AITrainer aiTrainer)
    {
        this.mainPlayer = mainPl;
        this.opponent = aiTrainer;
    }
    
    private void AssignMoves()
    {
        // assigns the move1 function of the current pokemon use by the player to the first button
        buttonsUI[0].onClick.AddListener(() => mainPlayer.pokemonParty[playerCurrentPokemon].move1.PerformMove
            (ref opponent.trainerInfo.pokemonParty, opponentCurrentPokemon)
        );
        buttonsUI[0].onClick.AddListener(() => Debug.LogError($"Click 'Move1' : {opponent.trainerInfo.pokemonParty[opponentCurrentPokemon].healthPoints}"));
        // instantly let the aiTrainer attack the player's pokemon
        buttonsUI[0].onClick.AddListener(AiRandomMove);
        // assigns the move2 function of the current pokemon use by the player to the second button
        buttonsUI[1].onClick.AddListener(() => mainPlayer.pokemonParty[playerCurrentPokemon].move2.PerformMove
            (ref opponent.trainerInfo.pokemonParty, opponentCurrentPokemon)
        );
        buttonsUI[1].onClick.AddListener(() => Debug.LogError($"Click 'Move2' : {opponent.trainerInfo.pokemonParty[opponentCurrentPokemon].healthPoints}"));
        // instantly let the aiTrainer attack the player's pokemon
        buttonsUI[1].onClick.AddListener(AiRandomMove);
    }

    private void AiRandomMove()
    {
        // if the pokemon is dead
        //if ()

        // randomly selects a move from the 2 moves
        int randMove = Random.Range(0, 2);
        // opponent attack using move1
        if (randMove == 0)
        {
            opponent.trainerInfo.pokemonParty[opponentCurrentPokemon].move1
            .PerformMove(ref mainPlayer.pokemonParty, playerCurrentPokemon);
            Debug.LogError($"Opponent Attack 'Move1' : {mainPlayer.pokemonParty[playerCurrentPokemon].healthPoints}");
        }
        // opponent attack using move2
        else if (randMove == 1)
        {
            opponent.trainerInfo.pokemonParty[opponentCurrentPokemon].move2
                .PerformMove(ref mainPlayer.pokemonParty, playerCurrentPokemon);
            Debug.LogError($"Opponent Attack 'Move2' : {mainPlayer.pokemonParty[playerCurrentPokemon].healthPoints}");
        }

    // after activating move, reset the button events
        buttonsUI[0].onClick.RemoveAllListeners();
        // after activating move, reset the button events
        buttonsUI[1].onClick.RemoveAllListeners();
    }
    


}
