using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class WinCardGameState : CardGameState
{
    public static event Action WinGame;
    [SerializeField] Text _playerLoseTextUI = null;


    public override void Enter()
    {
        WinGame?.Invoke();
    }

    public override void Exit()
    {
       
    }
}
