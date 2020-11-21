using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AICardToHand : MonoBehaviour
{
    public List<Cards> currentCard = new List<Cards>();

    public int currentId;

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

    public static int DrawX;
    public int drawXcards;
    public int addXmaxMana;

    public int hurted;
    public int actualpower;
    public int returnXcards;

    public GameObject Hand;

    public int z = 0;
    public GameObject It;

    public int numberOfCardsInDeck;


    void Start()
    {
        currentCard[0] = CardDataBase.cardList[currentId];
        Hand = GameObject.Find("EnemyHand");

        z = 0;
        numberOfCardsInDeck = AI.deckSize;
    }

    
    void Update()
    {
        if(z == 0)
        {
            It.transform.SetParent(Hand.transform);
            It.transform.localScale = Vector3.one;
            It.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
            It.transform.eulerAngles = new Vector3(25, 0, 0);
            z = 1;
        }

        id = currentCard[0].id;
        cardName = currentCard[0].cardName;
        cost = currentCard[0].cost;
        power = currentCard[0].power;
        cardDescription = currentCard[0].cardDescription;
        currentSprite = currentCard[0].currentImage;

        drawXcards = currentCard[0].drawXcards;
        addXmaxMana = currentCard[0].addXmaxMana;

        returnXcards = currentCard[0].returnXcards;

        nameText.text = "" + cardName;
        costText.text = "" + cost;

        actualpower = power - hurted;

        powerText.text = "" + actualpower;
        descriptionText.text = " " + cardDescription;

        currentImage.sprite = currentSprite;

        if (currentCard[0].color == "Red")
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

        if(this.tag == "EnemyAIClones")
        {
            currentCard[0] = AI.staticEnemyDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            AI.deckSize -= 1;
            this.tag = "Untagged";
        }
    }
}
