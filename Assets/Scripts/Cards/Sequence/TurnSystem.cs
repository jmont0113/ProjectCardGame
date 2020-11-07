﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public static bool isPlayerTurn;
    public int playerTurn;
    public int enemyTurn;
    public Text turnText;

    public static int maxMana;
    public static int currentMana;
    public Text manaText;

    public static bool startTurn;

    void Start()
    {
        isPlayerTurn = true;
        playerTurn = 1;
        enemyTurn = 0;

        maxMana = 1;
        currentMana = 1;

        startTurn = false;
    }

    void Update()
    {
        if(isPlayerTurn == true)
        {
            turnText.text = "Your Turn";
        }
        else
        {
            turnText.text = "Enemy Turn";
            
        }
        manaText.text = currentMana + "/" + maxMana;
    }

    public void EndPlayerTurn()
    {
        isPlayerTurn = false;
        enemyTurn += 1;
    }

    public void EndEnemyTurn()
    {
        isPlayerTurn = true;
        playerTurn += 1;
        maxMana += 1;
        currentMana = maxMana;

        startTurn = true;
    }
}