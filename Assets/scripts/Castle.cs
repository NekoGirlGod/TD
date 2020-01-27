using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public float HP;
    public int Money = 100;
    public GameObject MoneyTMPro;
    public GameObject HPTMPro;

    TextMeshProUGUI moneyText;
    TextMeshProUGUI HPText;
    // Start is called before the first frame update
    void Start()
    {
        // moneyText.text = Convert.ToString(Money);
        moneyText= MoneyTMPro.GetComponent<TextMeshProUGUI>();
        moneyText.text = Money.ToString();

        HPText = HPTMPro.GetComponent<TextMeshProUGUI>();
        HPText.text = HP.ToString();
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
            HPText.text = "0";
        }
        HPText.text = HP.ToString();
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
