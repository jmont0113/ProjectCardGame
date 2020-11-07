﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public static float maxHp;
    public static float staticHp;
    public float hp;
    public Image Health;
    public Text hpText;

    void Start()
    {
        maxHp = 25000.0f;
        staticHp = 20000.0f;
    }

    void Update()
    {
        hp = staticHp;
        Health.fillAmount = hp / maxHp;

        if (hp >= maxHp)
        {
            hp = maxHp;
        }
        hpText.text = hp + " HP";
    }
}