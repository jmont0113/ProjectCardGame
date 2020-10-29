using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGameUIController : MonoBehaviour
{
    [SerializeField] Text _enemyThinkingTextUI = null;
    [SerializeField] Text _playerLoseTextUI = null;
    [SerializeField] Text _playerWinTextUI = null;

    private void OnEnable()
    {
        BotTurnState.BotTurnBegan += OnBotTurnBegan;
        BotTurnState.BotTurnEnded += OnBotTurnEnded;
        LoseCardGameState.LoseGame += OnLoseCardGame;
        WinCardGameState.WinGame += OnWinCardGame;
    }

    private void OnDisable()
    {
        BotTurnState.BotTurnBegan -= OnBotTurnBegan;
        BotTurnState.BotTurnEnded -= OnBotTurnEnded;
        LoseCardGameState.LoseGame -= OnLoseCardGame;
        WinCardGameState.WinGame -= OnWinCardGame;
    }

    private void Start()
    {
        // make sure text is disable on start
        _enemyThinkingTextUI.gameObject.SetActive(false);
         _playerLoseTextUI.gameObject.SetActive(false);
         _playerWinTextUI.gameObject.SetActive(false);
    }

    void OnBotTurnBegan()
    {
        _enemyThinkingTextUI.gameObject.SetActive(true);
    }

    void OnBotTurnEnded()
    {
        _enemyThinkingTextUI.gameObject.SetActive(false);
    }

    void OnLoseCardGame()
    {
        _playerLoseTextUI.gameObject.SetActive(true);
    }

    void OnWinCardGame()
    {
        _playerWinTextUI.gameObject.SetActive(true);
    }
}
