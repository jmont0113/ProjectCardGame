﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotTurnState : CardGameState
{
    [Header("Enemy Turn Settings")]
    [SerializeField] float _botPauseDuration = 2f;

    CardPlayer _player;

    int _cardsToDraw;
    Coroutine _enemyPauseRoutine = null;
    CardGameDeckController _deckController = null;
    CardPlayerController _playerController = null;
    Deck<AbilityCard> _abilityCardDeck = null;

    public static event Action BotTurnBegan;
    public static event Action BotTurnEnded;
    public static event Action LoseGame;

    private void Start()
    {
        _deckController = StateMachine.DeckController;
        _playerController = StateMachine.PlayerController;
        _abilityCardDeck = _deckController.AbilityCardDeck;

        _cardsToDraw = StateMachine.CardDrawPerTurn;
    }

    public override void Enter()
    {
        Debug.Log("ENEMY TURN");
        _player = _playerController.CurrentPlayer;

        Debug.Log("Enemy draws 2 cards");
        int cardsToDraw = StateMachine.CardDrawPerTurn;
        _player.DrawAbilityCard(_cardsToDraw, _abilityCardDeck);

        BotTurnBegan?.Invoke();

        Debug.Log("...Enemy Thinking...");
        if (_enemyPauseRoutine != null)
            StopCoroutine(_enemyPauseRoutine);
        _enemyPauseRoutine = StartCoroutine(EnemyPauseRoutine(_botPauseDuration));
    }

    public override void Exit()
    {
        // just in case
        if (_enemyPauseRoutine != null)
            StopCoroutine(_enemyPauseRoutine);
    }

    IEnumerator EnemyPauseRoutine(float pauseDuration)
    {
        // wait for thinking
        yield return new WaitForSeconds(pauseDuration);
        Debug.Log("Enemy Acted.");
        BotTurnEnded?.Invoke();
        StateMachine.ChangeState<DecideNextPlayerState>();
    }
}
