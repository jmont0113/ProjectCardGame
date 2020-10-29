using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class LoseCardGameState : CardGameState
{
    public static event Action LoseGame;
    [SerializeField] Text _playerLoseTextUI = null;

    public override void Enter()
    {
        LoseGame?.Invoke();
    }

    public override void Exit()
    {

    }
}
