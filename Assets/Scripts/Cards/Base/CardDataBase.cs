using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Cards> cardList = new List<Cards>();

    void Awake()
    {
        cardList.Add(new Cards(0, "None", 0, 0, "None", Resources.Load<Sprite>("0"), "None", 0, 0, 0, 0, false, 0));
        cardList.Add(new Cards(1, "Warrior", 3, 3000, "Draw 2 Cards", Resources.Load<Sprite>("1"), "Red", 2, 0, 0, 0, false, 0));
        cardList.Add(new Cards(2, "Rogue", 2, 2000, "Add 1 max Mana", Resources.Load<Sprite>("2"), "Blue", 0, 1, 0, 0, false, 0));
        cardList.Add(new Cards(3, "Healer", 5, 3000, "Heal 2000", Resources.Load<Sprite>("3"), "Yellow", 0, 0, 0, 2000, false, 0));
        cardList.Add(new Cards(4, "Monk", 1, 1000, "Draw 1 Card", Resources.Load<Sprite>("4"), "Purple", 1, 0, 0, 0, false, 0));
        cardList.Add(new Cards(5, "Barbarian", 4, 4000, "Add 2 max Mana", Resources.Load<Sprite>("5"), "Red", 0, 2, 0, 0, false, 0));
        cardList.Add(new Cards(6, "Bard", 2, 2000, "Draw 2 Cards", Resources.Load<Sprite>("6"), "Blue", 2, 0, 0, 0, false, 0));
        cardList.Add(new Cards(7, "Amazon", 7, 7000, "Add 1 max Mana", Resources.Load<Sprite>("7"), "Yellow", 0, 1, 0, 0, false, 0));
        cardList.Add(new Cards(8, "Necromancer", 5, 5000, "Add 3 max Mana", Resources.Load<Sprite>("8"), "Purple", 0, 3, 0, 0, false, 0));
        cardList.Add(new Cards(9, "Paladin", 4, 4000, "Draw 1 Card", Resources.Load<Sprite>("9"), "Red", 1, 0, 0, 0, false, 0));
        cardList.Add(new Cards(10, "Assassin", 6, 6000, "Add 1 max Mana", Resources.Load<Sprite>("10"), "Blue", 0, 1, 0, 0, false, 0));
        cardList.Add(new Cards(11, "Sorcerer", 8, 7000, "Deal 300 Damage", Resources.Load<Sprite>("11"), "Yellow", 0, 2, 0, 0, true, 3000));
        cardList.Add(new Cards(12, "Fireball", 6, 8000, "Draw 2 Cards", Resources.Load<Sprite>("12"), "Purple", 2, 0, 1, 0, true, 0));
    }
}
