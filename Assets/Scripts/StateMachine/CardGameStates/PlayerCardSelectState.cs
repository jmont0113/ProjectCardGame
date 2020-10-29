﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// This Card Game State is where the player selects which card from their
/// hand they'd like to use.
/// </summary>
public class PlayerCardSelectState : CardGameState
{
    CardPlayer _player = null;
    int _currentSelectionIndex = 0;

    int PlayerHandSize => _player.Hand.Count;

    InputController _input = null;

    private void Start()
    {
        _input = StateMachine.Input;
    }

    public override void Enter()
    {
        _player = StateMachine.PlayerController.CurrentPlayer;

        Debug.Log("Player Card Select");
        _input.PressedRight += OnPressedRight;
        _input.PressedLeft += OnPressedLeft;
        _input.PressedConfirmed += OnPressedConfirm;

        Debug.Log("Initial Selected Card: " + _player.CurrentSelectedCard.Name);
    }

    public override void Exit()
    {
        _input.PressedRight -= OnPressedRight;
        _input.PressedLeft -= OnPressedLeft;
        _input.PressedConfirmed -= OnPressedConfirm;
    }

    void OnPressedRight()
    {
        // move to next selection
        _currentSelectionIndex = ArrayHelper.GetNextLoopedIndex(_currentSelectionIndex, PlayerHandSize);
        _player.SelectCard(_currentSelectionIndex);
    }

    void OnPressedLeft()
    {
        _currentSelectionIndex = ArrayHelper.GetPreviousLoopedIndex(_currentSelectionIndex, PlayerHandSize);
        _player.SelectCard(_currentSelectionIndex);
    }

    void OnPressedConfirm()
    {
        StateMachine.ChangeState<SelectTargetPlayerState>();
    }
}
