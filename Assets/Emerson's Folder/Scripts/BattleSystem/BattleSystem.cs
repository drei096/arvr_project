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
    private GameObject playerPokemon;
    private GameObject opponentPokemon;

    // buttons for the two move of the pokemon; assure that the size is 
    [SerializeField] private Button[] buttonsUI;
    [SerializeField] private Button AttackButton;

    // other scripts
    private GameObjectHandler GOHandler;

    void Start()
    { 
        playerCurrentPokemon = 0; 
        opponentCurrentPokemon = 0;
        GOHandler = GameObject.FindGameObjectWithTag("ScriptsHolder").GetComponent<GameObjectHandler>();
        AttackButton.onClick.AddListener(AssignMoves);
    }

    private void ResetBattleStats()
    {
        playerCurrentPokemon = 0; 
        opponentCurrentPokemon = 0;
    }

    public void StartBattle(MainPlayer mainPl, AITrainer aiTrainer)
    {
        // Reset stats
        ResetBattleStats();
        mainPl.RestorePartyHealth();
        // assign field references
        this.mainPlayer = mainPl;
        this.opponent = aiTrainer;
        playerParty = mainPl.pokemonParty;
        opponentParty = aiTrainer.trainerInfo.pokemonParty;
        // spawns the first pokemon of player
        playerPokemon = FindObjectOfType<PokemonPool>().itemPool.RequestPoolable(playerParty[playerCurrentPokemon].pokemonCode,
            new StructHandler.OnRequestStruct()
            {
                parent = GOHandler.plPokemonPos.transform,
                position = GOHandler.plPokemonPos.transform.position
            });
        // spawns the first pokemon of opponent
        opponentPokemon = FindObjectOfType<PokemonPool>().itemPool.RequestPoolable(opponentParty[opponentCurrentPokemon].pokemonCode,
                new StructHandler.OnRequestStruct()
                {
                    parent = GOHandler.opPokemonPos.transform,
                    position = GOHandler.opPokemonPos.transform.position
                });
    }
    
    private void AssignMoves()
    {
        // assigns the move1 function of the current pokemon use by the player to the first button
        buttonsUI[0].onClick.AddListener(() => playerParty[playerCurrentPokemon].move1.PerformMove
            (ref opponentParty, opponentCurrentPokemon)
        );
        // instantly let the aiTrainer attack the player's pokemon
        buttonsUI[0].onClick.AddListener(AiRandomMove);
        // assigns the move2 function of the current pokemon use by the player to the second button
        buttonsUI[1].onClick.AddListener(() => playerParty[playerCurrentPokemon].move2.PerformMove
            (ref opponentParty, opponentCurrentPokemon)
        );
        // instantly let the aiTrainer attack the player's pokemon
        buttonsUI[1].onClick.AddListener(AiRandomMove);
    }

    private void AiRandomMove()
    {
        // check if Battle is over; if '1', then terminate battle
        if (CheckOpponentPokemonParty() == 1)
            return;

        // randomly selects a move from the 2 moves
        int randMove = Random.Range(0, 2);
        // opponent attack using move1
        if (randMove == 0)
        {
            opponentParty[opponentCurrentPokemon].move1
                .PerformMove(ref playerParty, playerCurrentPokemon);
        }
        // opponent attack using move2
        else if (randMove == 1)
        {
            opponentParty[opponentCurrentPokemon].move2
                .PerformMove(ref playerParty, playerCurrentPokemon);
        }
        
        // check if Battle is over; if '1', then terminate battle
        if (CheckPlayerPokemonParty() == 1)
            return;

        // after activating move, reset the button events
        buttonsUI[0].onClick.RemoveAllListeners();
        // after activating move, reset the button events
        buttonsUI[1].onClick.RemoveAllListeners();
    }

    private int CheckPlayerPokemonParty()
    {
        Debug.LogError($"Check Player PokemonIndex : {playerCurrentPokemon}");
        Debug.LogError($"Check Player CurrentPokemon : {playerParty[playerCurrentPokemon].name}");
        Debug.LogError($"Check Player Pokemon Health : {playerParty[playerCurrentPokemon].healthPoints}");
        if (playerParty[playerCurrentPokemon].healthPoints <= 0)
        {
            Debug.LogError($"Player Pokemon Dead!!");
            // if the opponent's pokemon is dead, release it
            FindObjectOfType<PokemonPool>().itemPool.ReleasePoolable(playerPokemon,
                new StructHandler.OnReleaseStruct()
                {
                    parent = GOHandler.PoolManager.transform,
                    position = GOHandler.PoolManager.transform.position
                });
            // check if there are no more pokemon in the party    
            if (++playerCurrentPokemon >= GameManager.MAX_PARTY_SIZE || playerParty.Count < playerCurrentPokemon + 1)
            {
                Debug.LogError($"No More Pokemon in Player!! : {playerCurrentPokemon}");
                // Release trainer
                FindObjectOfType<TrainerPool>().itemPool.ReleasePoolable(opponent.gameObject,
                    new StructHandler.OnReleaseStruct()
                    {
                        parent = GOHandler.PoolManager.transform,
                        position = GOHandler.PoolManager.transform.position
                    });
                // Release Player Pokemon
                FindObjectOfType<PokemonPool>().itemPool.ReleasePoolable(opponentPokemon,
                    new StructHandler.OnReleaseStruct()
                    {
                        parent = GOHandler.PoolManager.transform,
                        position = GOHandler.PoolManager.transform.position
                    });
                // finish battle, proceed with walking; disable the buttons
                StepCount.Instance.EnableCanCount();
                // terminate battle system
                return 1;
            }
            // spawns the next pokemon
            playerPokemon = FindObjectOfType<PokemonPool>().itemPool.RequestPoolable(playerParty[playerCurrentPokemon].pokemonCode,
                new StructHandler.OnRequestStruct()
                {
                    parent = GOHandler.plPokemonPos.transform,
                    position = GOHandler.plPokemonPos.transform.position
                });
        }

        return 0;
    }

    private int CheckOpponentPokemonParty()
    {
        Debug.LogError($"Check Opponent PokemonIndex : {opponentCurrentPokemon}");
        Debug.LogError($"Check Opponent CurrentPokemon : {opponentParty[opponentCurrentPokemon].name}");
        Debug.LogError($"Check Opponent Pokemon Health : {opponentParty[opponentCurrentPokemon].healthPoints}");
        if (opponentParty[opponentCurrentPokemon].healthPoints <= 0)
        {
            Debug.LogError($"Opponent Pokemon Dead!!");
            // if the opponent's pokemon is dead, release it
            FindObjectOfType<PokemonPool>().itemPool.ReleasePoolable(opponentPokemon,
                new StructHandler.OnReleaseStruct()
                {
                    parent = GOHandler.PoolManager.transform,
                    position = GOHandler.PoolManager.transform.position
                });
            // check if there are no more pokemon in the party    
            if (++opponentCurrentPokemon >= GameManager.MAX_PARTY_SIZE || opponentParty.Count < opponentCurrentPokemon + 1)
            {
                Debug.LogError($"No More Pokemon in Opponent!! : {opponentCurrentPokemon}");

                AudioManager.Instance.Stop(SoundCode.BGM_ENCOUNTER_START);
                AudioManager.Instance.Play(SoundCode.BGM_VICTORY);

                // Release trainer
                FindObjectOfType<TrainerPool>().itemPool.ReleasePoolable(opponent.gameObject,
                    new StructHandler.OnReleaseStruct()
                    {
                        parent = GOHandler.PoolManager.transform,
                        position = GOHandler.PoolManager.transform.position
                    });
                // Release Player Pokemon
                FindObjectOfType<PokemonPool>().itemPool.ReleasePoolable(playerPokemon,
                    new StructHandler.OnReleaseStruct()
                    {
                        parent = GOHandler.PoolManager.transform,
                        position = GOHandler.PoolManager.transform.position
                    });
                // finish battle, proceed with walking; disable the buttons
                StepCount.Instance.EnableCanCount();
                // terminate battle system
                return 1;
            }
            // spawns the next pokemon
            opponentPokemon = FindObjectOfType<PokemonPool>().itemPool.RequestPoolable(opponentParty[opponentCurrentPokemon].pokemonCode,
                new StructHandler.OnRequestStruct()
                {
                    parent = GOHandler.opPokemonPos.transform,
                    position = GOHandler.opPokemonPos.transform.position
                });
        }

        return 0;
    }
    
}
