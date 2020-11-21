using System.Collections;
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

    public int random;

    public bool turnEnd;
    public Text timerText;
    public int seconds;
    public bool timerStart;

    public static int maxEnemyMana;
    public static int currentEnemyMana;
    public Text enemyManaText;

    void Start()
    {
        StartGame();
        seconds = 10;
        timerStart = true;
    }

    void Update()
    {
        if(isPlayerTurn == true)
        {
            turnText.text = "Player Turn";
        }
        else
        {
            turnText.text = "Enemy Turn";
            
        }
        manaText.text = currentMana + "/" + maxMana;

        if(isPlayerTurn == true && seconds > 0 && timerStart == true)
        {
            StartCoroutine(Timer());
            timerStart = false;
        }

        if(seconds == 0 && isPlayerTurn == true)
        {
            EndPlayerTurn();
            timerStart = true;
            seconds = 10;
        }

        timerText.text = seconds + "";

        if(isPlayerTurn == false && seconds > 0 && timerStart == true)
        {
            StartCoroutine(EnemyTimer());
            timerStart = false;
        }

        if(seconds == 0 && isPlayerTurn == false)
        {
            EndEnemyTurn();
            timerStart = true;
            seconds = 10;
        }

        enemyManaText.text = currentEnemyMana + "/" + maxEnemyMana;
    }

    public void EndPlayerTurn()
    {
        isPlayerTurn = false;
        enemyTurn += 1;

        maxEnemyMana += 1;
        currentEnemyMana += 1;
        //currentEnemyMana = maxEnemyMana;

        AI.draw = false;

    }

    public void EndEnemyTurn()
    {
        isPlayerTurn = true;
        playerTurn += 1;
        maxMana += 1;
        currentMana = maxMana;

        startTurn = true;
    }

    public void StartGame()
    {
        random = Random.Range(0, 2);
        if(random == 0)
        {
            isPlayerTurn = true;
            playerTurn = 1;
            enemyTurn = 0;

            maxMana = 1;
            currentMana = 1;

            maxEnemyMana = 0;
            currentEnemyMana = 0;

            startTurn = false;
        }

        if(random == 1)
        {
            isPlayerTurn = false;
            playerTurn = 0;
            enemyTurn = 1;

            maxMana = 0;
            currentMana = 0;

            maxEnemyMana = 1;
            currentEnemyMana = 1;

           // startTurn = true;
        }
    }

    IEnumerator Timer()
    {
        if(isPlayerTurn == true && seconds > 0)
        {
            yield return new WaitForSeconds(1);
            seconds--;
            StartCoroutine(Timer());
        }
    }

    IEnumerator EnemyTimer()
    {
        if (isPlayerTurn == false && seconds > 0)
        {
            yield return new WaitForSeconds(1);
            seconds--;
            StartCoroutine(EnemyTimer());
        }
    }
}
