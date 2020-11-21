using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public List<Cards> deck = new List<Cards>();
    public List<Cards> containter = new List<Cards>();
    public static List<Cards> staticEnemyDeck = new List<Cards>();

    public GameObject Hand;
    public GameObject Zone;
    public GameObject Graveyard;

    public int x;
    public static int deckSize;

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject cardToHand;

    public GameObject[] EnemyClones;

    public static bool draw;

    public GameObject CardBack;

    void Start()
    {
        StartCoroutine(StartGame());

        Hand = GameObject.Find("EnemyHand");
        Zone = GameObject.Find("MyEnemyZone");
        Graveyard = GameObject.Find("Enemy Graveyard");

        x = 0;
        deckSize = 40;
        draw = true;

        for(int i = 0; i < deckSize; i++)
        {
            x = Random.Range(1, 7);
            deck[i] = CardDataBase.cardList[x];
        }
    }

    void Update()
    {
        staticEnemyDeck = deck;

        if(deckSize < 30)
        {
            cardInDeck1.SetActive(false);
        }
        if (deckSize < 20)
        {
            cardInDeck2.SetActive(false);
        }
        if (deckSize < 2)
        {
            cardInDeck3.SetActive(false);
        }
        if (deckSize < 1)
        {
            cardInDeck4.SetActive(false);
        }

        if(CurrentCard.drawX > 0)
        {
            StartCoroutine(Draw(CurrentCard.drawX));
            CurrentCard.drawX = 0;
        }

        if(TurnSystem.startTurn == false && draw == false)
        {
            StartCoroutine(Draw(1));
            draw = true;
        }
    }

    public void Shuffle()
    {
        for(int i = 0; i < deckSize; i++)
        {
            containter[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = containter[0];
        }

        Instantiate(CardBack, transform.position, transform.rotation);
        StartCoroutine(ShuffleNow());
    }

    IEnumerator StartGame()
    {
        for(int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(cardToHand, transform.position, transform.rotation);

        }
    }

    IEnumerator ShuffleNow()
    {
        yield return new WaitForSeconds(1);
        EnemyClones = GameObject.FindGameObjectsWithTag("EnemyAIClones");

        foreach (GameObject EnemyAIClones in EnemyClones)
        {
            Destroy(EnemyAIClones);
        }
    }

    IEnumerator Draw(int x)
    {
        for(int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(cardToHand, transform.position, transform.rotation);
        }
    }
}
