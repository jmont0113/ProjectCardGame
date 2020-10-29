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

    void Start()
    {
        currentCard[0] = CardDataBase.cardList[currentID];
    }

    void Update()
    {
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
    }
}
