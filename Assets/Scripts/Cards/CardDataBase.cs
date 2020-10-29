using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Cards> cardList = new List<Cards>();

    void Awake()
    {
        cardList.Add(new Cards(0, "None", 0, 0, "None", Resources.Load<Sprite>("0")));
        cardList.Add(new Cards(1, "Warrior", 3, 3000, "It's Warrior", Resources.Load<Sprite>("1")));
        cardList.Add(new Cards(2, "Rogue", 2, 2000, "It's Rogue", Resources.Load<Sprite>("2")));
        cardList.Add(new Cards(3, "Sorcerer", 5, 3000, "It's Sorcerer", Resources.Load<Sprite>("3")));
        cardList.Add(new Cards(4, "Monk", 1, 1000, "It's Monk", Resources.Load<Sprite>("4")));
        cardList.Add(new Cards(5, "Barbarian", 4, 4000, "It's Barbarian", Resources.Load<Sprite>("5")));
        cardList.Add(new Cards(6, "Bard", 2, 2000, "It's Bard", Resources.Load<Sprite>("6")));
        cardList.Add(new Cards(7, "Amazon", 7, 7000, "It's Amazon", Resources.Load<Sprite>("7")));
        cardList.Add(new Cards(8, "Necromancer", 5, 5000, "It's Necromancer", Resources.Load<Sprite>("8")));
        cardList.Add(new Cards(9, "Paladin", 4, 4000, "It's Paladin", Resources.Load<Sprite>("9")));
        cardList.Add(new Cards(10, "Assassin", 6, 6000, "It's Assassin", Resources.Load<Sprite>("10")));
        cardList.Add(new Cards(11, "Druid", 8, 8000, "It's Druid", Resources.Load<Sprite>("11")));
        cardList.Add(new Cards(11, "Crusader", 8, 8000, "It's Crusader", Resources.Load<Sprite>("12")));
    }
}
