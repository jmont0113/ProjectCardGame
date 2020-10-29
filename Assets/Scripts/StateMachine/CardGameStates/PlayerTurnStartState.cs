using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(CardGameSM))]
public class PlayerTurnStartState : CardGameState
{
    [SerializeField] Text _playerTurnTextUI = null;

    int _playerTurnCount = 0;

    int _cardsToDraw;

    CardGameDeckController _deckController = null;
    CardPlayerController _playerController = null;
    Deck<AbilityCard> _abilityCardDeck = null;

    CardPlayer _player;
    Coroutine _playerStartRoutine = null;

    public static event Action WinGame;

    private void Start()
    {
        _deckController = StateMachine.DeckController;
        _playerController = StateMachine.PlayerController;
        _abilityCardDeck = _deckController.AbilityCardDeck;
        _cardsToDraw = StateMachine.CardDrawPerTurn;
    }

    public override void Enter()
    {
        Debug.Log("Player Turn: ...Entering");
        _playerTurnTextUI.gameObject.SetActive(true);

        _playerTurnCount++;
        _playerTurnTextUI.text = "Player Turn: " + _playerTurnCount.ToString();
        // hook into events
        StateMachine.Input.PressedConfirmed += OnPressedConfirm;

        Debug.Log("PLAYER TURN");
        _player = _playerController.CurrentPlayer;

        // start player turn setup animation
        if (_playerStartRoutine != null)
            StopCoroutine(_playerStartRoutine);
        _playerStartRoutine = StartCoroutine(TurnStartRoutine());
    }

    void OnPressedConfirm()
    {
        StateMachine.ChangeState<BotTurnState>();
    }

    public override void Exit()
    {
        _playerTurnTextUI.gameObject.SetActive(false);
        // unhook from events
        StateMachine.Input.PressedConfirmed -= OnPressedConfirm;
        Debug.Log("Player Turn: Exiting...");
    }

    IEnumerator TurnStartRoutine()
    {
        Debug.Log("Player draws 2 cards");
        _player.DrawAbilityCard(_cardsToDraw, _abilityCardDeck);

        yield return new WaitForSeconds(1.5f);

        StateMachine.ChangeState<PlayerCardSelectState>();
    }
}
