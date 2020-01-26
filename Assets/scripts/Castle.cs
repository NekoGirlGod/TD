using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public float HP;
    public int Money = 100;
    public Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = Convert.ToString(Money);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetDamage(float Damage)
    {
        HP -= Damage;
        if (HP <= 0)
        {
            Loosing();
        }
    }
    public void Loosing()
    {
        Destroy(gameObject);
    }

    public void setMoney(int money)
    {
        Money += money;
        moneyText.text = Convert.ToString(Money);
    }
}
