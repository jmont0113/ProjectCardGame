using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInCollection : MonoBehaviour
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

    public bool beGrey;
    public GameObject frame;

    void Start()
    {
        currentCard[0] = CardDataBase.cardList[currentID];
    }

    
    void Update()
    {
        currentCard[0] = CardDataBase.cardList[currentID];

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

        if(beGrey == true)
        {
            frame.GetComponent<Image>().color = new Color32(155, 155, 155, 255);
        }
        else
        {
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
        }
    }
}
