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

    public static int drawX;
    public int drawXcards;
    public int addXmaxMana;

    public GameObject attackBorder;

    public GameObject Target;
    public GameObject Enemy;

    public bool summoningSickness;
    public bool canAttack;
    public bool cantAttack;

    public static bool staticTargeting;
    public static bool staticTargetingEnemy;

    public bool targeting;
    public bool targetingEnemy;

    public bool onlyCurrentCardAttack;

    public GameObject summonBorder;

    public bool canBeDestroyed;
    public GameObject Graveyard;
    public bool beInGraveyard;

    void Start()
    {
        currentCard[0] = CardDataBase.cardList[currentID];
        numberOfCardsInDeck = PlayerDeck.deckSize;
        canBeSummon = false;
        summoned = false;

        drawX = 0;

        canAttack = false;
        summoningSickness = true;

        Enemy = GameObject.Find("Enemy HP");

        targeting = false;
        targetingEnemy = false;
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

        drawXcards = currentCard[0].drawXcards;
        addXmaxMana = currentCard[0].addXmaxMana;

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
            if (TurnSystem.currentMana >= cost && summoned == false && beInGraveyard == false)
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

            if (canAttack == true)
            {
                attackBorder.SetActive(true);
            }
            else
            {
                attackBorder.SetActive(false);
            }

            if(TurnSystem.isPlayerTurn == false && summoned == true)
            {
                summoningSickness = false;
                cantAttack = false;
            }

            if(TurnSystem.isPlayerTurn == true && summoningSickness == false && cantAttack == false)
            {
                canAttack = true;
            }
            else
            {
                canAttack = false;
            }

            targeting = staticTargeting;
            targetingEnemy = staticTargetingEnemy;

            if(targetingEnemy == true)
            {
                Target = Enemy;
            }
            else
            {
                Target = null;
            }

            if(targeting == true && targetingEnemy == true && onlyCurrentCardAttack == true)
            {
                Attack();
            }

            if(canBeSummon == true)
            {
                summonBorder.SetActive(true);
            }
            else
            {
                summonBorder.SetActive(false);
            }
        }
    }

    public void Summon()
    {
        TurnSystem.currentMana -= cost;
        summoned = true;

        MaxMana(addXmaxMana);
        drawX = drawXcards;
    }

    public void MaxMana(int x)
    {
        TurnSystem.maxMana += x;
    }

    public void Attack()
    {
        if(canAttack == true && summoned == true)
        {
            if(Target != null)
            {
                if(Target == Enemy)
                {
                    EnemyHP.staticHp -= power;
                    targeting = false;
                    canAttack = true;
                }

                if(Target.name == "CardToHand(Clone)")
                {
                    canAttack = true;
                }
            }
        }
    }

    public void UntargetEnemy()
    {
        staticTargetingEnemy = false;
    }
    public void TargetEnemy()
    {
        staticTargetingEnemy = true;
    }
    public void StartAttack()
    {
        staticTargeting = true;

    }
    public void StopAttack()
    {
        staticTargeting = false;
    }
    public void OneCardAttack()
    {
        onlyCurrentCardAttack = true;
    }
    public void OneCardAttackStop()
    {
        onlyCurrentCardAttack = false;
    }
    public void Destroy()
    {
        Graveyard = GameObject.Find("My Graveyard");
        canBeDestroyed = true; // to test this void 
        if(canBeDestroyed == true)
        {
            this.transform.SetParent(Graveyard.transform);
            canBeDestroyed = false;
            summoned = false;
            beInGraveyard = true;
        }
    }
}
