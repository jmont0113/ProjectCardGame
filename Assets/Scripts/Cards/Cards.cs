using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Cards : ScriptableObject
{
    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;

    public Sprite currentImage;

    public Cards()
    {

    }

    public Cards(int ID, string CardName, int Cost, int Power, string CardDescription, Sprite CurrentImage)
    {
        id = ID;
        cardName = CardName;
        cost = Cost;
        power = Power;
        cardDescription = CardDescription;

        currentImage = CurrentImage;

    }
}
