using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CurrentCard : MonoBehaviour
{
    public List<Cards> currentCard = new List<Cards>();
    public int currentID;

    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;

    public Text nameText;
    public Text costText;
    public Text powerText;
    public Text descriptionText;

    public Sprite currentSprite;
    public Image currentImage;

    public Image frame;

    public bool cardBack;
    public static bool staticCardBack;

    public GameObject Hand;
    public int numberOfCardsInDeck;

    public bool canBeSummon;
    public bool summoned;
    public GameObject battleZone;

    void Start()
    {
        currentCard[0] = CardDataBase.cardList[currentID];
        numberOfCardsInDeck = PlayerDeck.deckSize;
        canBeSummon = false;
        summoned = false; 
    }

    void Update()
    {
        Hand = GameObject.Find("Hand");
        if(this.transform.parent == Hand.transform.parent)
        {
            cardBack = false;
        }

        id = currentCard[0].id;
        cardName = currentCard[0].cardName;
        cost = currentCard[0].cost;
        power = currentCard[0].power;
        cardDescription = currentCard[0].cardDescription;

        currentSprite = currentCard[0].currentImage;

        nameText.text = "" + cardName;
        costText.text = "" + cost;
        powerText.text = "" + power;
        descriptionText.text = " " + cardDescription;

        currentImage.sprite = currentSprite;

        if(currentCard[0].color == "Red")
        {
            frame.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
        if (currentCard[0].color == "Blue")
        {
            frame.GetComponent<Image>().color = new Color32(0, 0, 255, 255);
        }
        if (currentCard[0].color == "Yellow")
        {
            frame.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
        }
        if (currentCard[0].color == "Purple")
        {
            frame.GetComponent<Image>().color = new Color32(255, 0, 255, 255);
        }

        staticCardBack = cardBack;

        if (this.tag == "Clone")
        {
            currentCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";
        }

        if(this.tag != "Deck")
        {
            if (TurnSystem.currentMana >= cost && summoned == false)
            {
                canBeSummon = true;
            }
            else
            {
                canBeSummon = false;
            }

            if (canBeSummon == true)
            {
                gameObject.GetComponent<Draggable>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<Draggable>().enabled = false;
                battleZone = GameObject.Find("Zone");
            }

            if (summoned == false && this.transform.parent == battleZone.transform)
            {
                Summon();
            }
        }
    }

    public void Summon()
    {
        TurnSystem.currentMana -= cost;
        summoned = true;
    }
}
