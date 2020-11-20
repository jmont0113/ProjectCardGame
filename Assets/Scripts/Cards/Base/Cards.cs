using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Cards
{
    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;

    public int drawXcards;
    public int addXmaxMana;
    public Sprite currentImage;

    public string color;

    public int returnXcards;

    public int healXpower;

    public Cards()
    {

    }

    public Cards(int ID, string CardName, int Cost, int Power, string CardDescription, Sprite CurrentImage, string Color, int DrawXcards, int AddXmaxMana, int ReturnXcards, int HealXpower)
    {
        id = ID;
        cardName = CardName;
        cost = Cost;
        power = Power;
        cardDescription = CardDescription;

        currentImage = CurrentImage;

        color = Color;

        drawXcards = DrawXcards;
        addXmaxMana = AddXmaxMana;

        returnXcards = ReturnXcards;

        healXpower = HealXpower;
    }
}
