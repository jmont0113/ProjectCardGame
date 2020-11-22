using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text victoryText;
    public GameObject textObject;
    public AudioSource victory;
    public AudioSource youLose;
    
    void Start()
    {
        textObject.SetActive(false);
    }

    
    void Update()
    {
        if(PlayerHP.staticHp <= 0)
        {
            youLose.Play();
            textObject.SetActive(true);
            victoryText.text = "You Lose";
        }

        if (EnemyHP.staticHp <= 0)
        {
            victory.Play();
            textObject.SetActive(true);
            victoryText.text = "Victory";
        }
    }
}
