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
    private List<StructHandler.PokemonInfo> playerParty;
    private List<StructHandler.PokemonInfo> opponentParty;

    // buttons for the two move of the pokemon; assure that the size is 
    [SerializeField] private Button[] buttonsUI;
    [SerializeField] private Button AttackButton;

    // other scripts
    private GameObjectHandler GOHandler;

    void Start()
    {
        GOHandler = GameObject.FindGameObjectWithTag("ScriptsHolder").GetComponent<GameObjectHandler>();
        AttackButton.onClick.AddListener(AssignMoves);
        AttackButton.onClick.AddListener(() => Debug.LogError($"Click 'Attack'!"));
        // Temporary code; note that this is always requesting an AItrainer
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
        playerParty = mainPl.pokemonParty;
        opponentParty = aiTrainer.trainerInfo.pokemonParty;
    }
    
    private void AssignMoves()
    {
        // assigns the move1 function of the current pokemon use by the player to the first button
        buttonsUI[0].onClick.AddListener(() => playerParty[playerCurrentPokemon].move1.PerformMove
            (ref opponentParty, opponentCurrentPokemon)
        );
        buttonsUI[0].onClick.AddListener(() => Debug.LogError($"Click 'Move1' : " +
                                                              $"{opponentParty[opponentCurrentPokemon].healthPoints}"));
        // instantly let the aiTrainer attack the player's pokemon
        buttonsUI[0].onClick.AddListener(AiRandomMove);
        // assigns the move2 function of the current pokemon use by the player to the second button
        buttonsUI[1].onClick.AddListener(() => playerParty[playerCurrentPokemon].move2.PerformMove
            (ref opponentParty, opponentCurrentPokemon)
        );
        buttonsUI[1].onClick.AddListener(() => Debug.LogError($"Click 'Move2' : " +
                                                              $"{opponentParty[opponentCurrentPokemon].healthPoints}"));
        // instantly let the aiTrainer attack the player's pokemon
        buttonsUI[1].onClick.AddListener(AiRandomMove);
    }

    private void AiRandomMove()
    {
        // if the opponent's pokemon is dead
        /*
        if (opponent.trainerInfo.pokemonParty[opponentCurrentPokemon].healthPoints <= 0)
        {
            opponentCurrentPokemon += 1;
            FindObjectOfType<PokemonPool>().itemPool.RequestPoolable(opponentParty[opponentCurrentPokemon].pokemonCode,
                new StructHandler.OnRequestStruct()
                {
                    parent = GOHandler.opPokemonPos.transform,
                    position = GOHandler.opPokemonPos.transform.position
                });
        }
        */

        // randomly selects a move from the 2 moves
        int randMove = Random.Range(0, 2);
        // opponent attack using move1
        if (randMove == 0)
        {
            Debug.LogError($"IS POKEMON1 NULL: {opponentParty[opponentCurrentPokemon] == null}");
            Debug.LogError($"IS MOVE1 NULL: {opponentParty[opponentCurrentPokemon].move1 == null}");
            Debug.LogError($"POKEMON NAME: {opponentParty[opponentCurrentPokemon].name}");
            Debug.LogError($"MOVE NAME: {opponentParty[opponentCurrentPokemon].move1.name}");
            opponentParty[opponentCurrentPokemon].move1
            .PerformMove(ref playerParty, playerCurrentPokemon);
            Debug.LogError($"Opponent Attack 'Move1' : {playerParty[playerCurrentPokemon].healthPoints}");
        }
        // opponent attack using move2
        else if (randMove == 1)
        {
            Debug.LogError($"IS POKEMON1 NULL: {opponentParty[opponentCurrentPokemon] == null}");
            Debug.LogError($"IS MOVE2 NULL: {opponentParty[opponentCurrentPokemon].move1 == null}");
            Debug.LogError($"POKEMON NAME: {opponentParty[opponentCurrentPokemon].name}");
            Debug.LogError($"MOVE NAME: {opponentParty[opponentCurrentPokemon].move2.name}");
            opponentParty[opponentCurrentPokemon].move2
                .PerformMove(ref playerParty, playerCurrentPokemon);
            Debug.LogError($"Opponent Attack 'Move2' : {playerParty[playerCurrentPokemon].healthPoints}");
        }

        // after activating move, reset the button events
        buttonsUI[0].onClick.RemoveAllListeners();
        // after activating move, reset the button events
        buttonsUI[1].onClick.RemoveAllListeners();
    }
    


}
