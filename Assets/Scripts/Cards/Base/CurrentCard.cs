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

    public int hurted;
    public int actualpower;
    public int returnXcards;
    public bool useReturn;

    public static bool UcanReturn;

    public int healXpower;
    public bool canHeal;

    public GameObject EnemyZone;
    public AICardToHand aiCardToHand;

    public bool spell;
    public int damageDealtBySpell;

    public bool dealDamage;

    public bool stopDealDamage;

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

        canHeal = true;

        EnemyZone = GameObject.Find("MyEnemyZone");
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

        returnXcards = currentCard[0].returnXcards;

        healXpower = currentCard[0].healXpower;

        spell = currentCard[0].spell;
        damageDealtBySpell = currentCard[0].damageDealtBySpell;

        nameText.text = "" + cardName;
        costText.text = "" + cost;

        actualpower = power - hurted;

        powerText.text = "" + actualpower;
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
            if (TurnSystem.currentMana >= cost && summoned == false && beInGraveyard == false && TurnSystem.isPlayerTurn == true)
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

            if (canAttack == true && beInGraveyard == false)
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

            if(targeting == true && onlyCurrentCardAttack == true)
            {
                Attack();
            }

            if(canBeSummon == true || UcanReturn == true && beInGraveyard == true)
            {
                summonBorder.SetActive(true);
            }
            else
            {
                summonBorder.SetActive(false);
            }

            if(actualpower <= 0 && spell == false)
            {
                Destroy();
            }

            if(returnXcards > 0 && summoned == true && useReturn == false && TurnSystem.isPlayerTurn == true)
            {
                Return(returnXcards);
                useReturn = true;
            }

            if(TurnSystem.isPlayerTurn == false)
            {
                UcanReturn = false;
            }

            if(canHeal == true && summoned == true)
            {
                Heal();
                canHeal = false;
            }

            if(damageDealtBySpell > 0)
            {
                dealDamage = true;
            }

            if(dealDamage == true && this.transform.parent == battleZone.transform)
            {
                attackBorder.SetActive(true);
            }
            else
            {
                attackBorder.SetActive(false);
            }

            if(dealDamage == true && this.transform.parent == battleZone.transform)
            {
                dealxDamage(damageDealtBySpell);
            }

            if(stopDealDamage == true)
            {
                attackBorder.SetActive(false);
                dealDamage = false;
            }

            if(this.transform.parent == battleZone.transform && spell == true && dealDamage == false)
            {
                Destroy();
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
                    if (EnemyHP.staticHp < 0)
                    {
                        EnemyHP.staticHp = 0;
                    }
                }
                else
                {
                    foreach(Transform child in EnemyZone.transform)
                    {
                        if(child.GetComponent<AICardToHand>().isTarget == true)
                        {
                            child.GetComponent<AICardToHand>().hurted = power;
                            hurted = child.GetComponent<AICardToHand>().power;
                            cantAttack = true;
                        }
                    }
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
        canBeDestroyed = true; 
        if(canBeDestroyed == true)
        {
            this.transform.SetParent(Graveyard.transform);
            canBeDestroyed = false;
            summoned = false;
            beInGraveyard = true;
            hurted = 0;
        }
    }

    public void Return(int x)
    {
        for(int i = 0; i <= x; i++)
        {
            ReturnCard();
        }
    }

    public void ReturnCard()
    {
        UcanReturn = true;
    }

    public void ReturnThis()
    {
        if(beInGraveyard == true && UcanReturn == true)
        {
            this.transform.SetParent(Hand.transform);
            UcanReturn = false;
            beInGraveyard = false;
            summoningSickness = true;
        }
    }

    public void Heal()
    {
        PlayerHP.staticHp += healXpower;
    }

    public void dealxDamage(int x)
    {
        if(Target != null)
        {
            if(Target == Enemy && stopDealDamage == false && Input.GetMouseButton(0))
            {
                EnemyHP.staticHp -= damageDealtBySpell;
                stopDealDamage = true;
            }
        }
        else
        {
            foreach (Transform child in EnemyZone.transform)
            {
                if (child.GetComponent<AICardToHand>().isTarget == true && Input.GetMouseButton(0))
                {
                    child.GetComponent<AICardToHand>().hurted += damageDealtBySpell;
                    stopDealDamage = true;
                }
            }
        }
    }
}
