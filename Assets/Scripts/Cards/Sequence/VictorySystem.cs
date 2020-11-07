using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictorySystem : MonoBehaviour
{
    public GameObject victoryText;
    
    public void Victory()
    {
        victoryText.SetActive(true);
    }
}
