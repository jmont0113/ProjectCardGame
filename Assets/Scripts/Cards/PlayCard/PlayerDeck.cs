using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeck : MonoBehaviour
{
    public List<Cards> deck = new List<Cards>();
    public List<Cards> container = new List<Cards>();
    public static List<Cards> staticDeck = new List<Cards>();

    public int x;
    public static int deckSize;

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject CardToHand;

    public GameObject CardBack;
    public GameObject Deck;

    //public GameObject[] Clones;
    public GameObject[] ClonesDeck;

    public GameObject Hand;

    public Text LoseText;
    public GameObject LoseTextGameObject;

    void Awake()
    {
        Shuffle();
    }

    void Start()
    {
        x = 0;
        deckSize = 40;
        for(int i = 0; i < deckSize; i++)
        {
            x = Random.Range(1, 13);
            deck[i] = CardDataBase.cardList[x];
        }
        StartCoroutine(StartGame());
    }

    void Update()
    {
        if(deckSize <= 0)
        {
            LoseTextGameObject.SetActive(true);
            LoseText.text = "You Lose";
        }

        staticDeck = deck;

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

        if(TurnSystem.startTurn == true)
        {
            StartCoroutine(Draw(1));
            TurnSystem.startTurn = false;
        }
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
        //Clones = GameObject.FindGameObjectsWithTag("Clone");
        ClonesDeck = GameObject.FindGameObjectsWithTag("CloneDeck");
        //foreach (GameObject Clone in Clones)
        foreach (GameObject CloneDeck in ClonesDeck)
        {
            //Destroy(Clone);
            Destroy(CloneDeck);
        }
    }

    IEnumerator StartGame()
    {
        for(int i = 0; i <= 4; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

    public void Shuffle()
    {
        for(int i = 0; i < deckSize; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(1, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }
        Instantiate(CardBack, transform.position, transform.rotation);
        StartCoroutine(Example());
    }

    IEnumerator Draw(int x)
    {
        for(int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }
}
