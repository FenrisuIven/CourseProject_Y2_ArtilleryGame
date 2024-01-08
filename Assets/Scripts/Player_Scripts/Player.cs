using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHP;
    public int curHP;
    public bool dead;
    
    public Healthbar healthbar;

    private void Start()
    {
        healthbar.SetMaxHealth(maxHP);
        healthbar.SetHealth(curHP);
    }

    public int CurrHP
    {
        get { return curHP; }
        set
        {
            if (value > 0) curHP = value;
            else
            {
                curHP = 0;
                dead = true;
            }
        }
    }

    public void ReceiveDamage(int dmg)
    {
        CurrHP -= dmg;
        healthbar.SetHealth(CurrHP);
    }
}
