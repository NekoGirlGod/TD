using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enimy : MonoBehaviour
{
    public float HP = 100;
    public float speed = 1;
    public float Damage = 10;
    public int CoastMin = 10;
    public int CoastMax = 10;

    [System.NonSerialized]
    public GameObject castle;
    [System.NonSerialized]
    public GameObject spawner;

    List<GameObject> WPoints = new List<GameObject>();
    int wayIndex = 0;
    Castle castleScr;
    
    
    void Start()
    {
        WPoints = GameObject.Find("Main Camera").GetComponent<GameControllerScr>().WayPoints;
        if (castle != null)
        {
            castleScr = castle.GetComponent<Castle>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 dir = WPoints[wayIndex].transform.position - transform.position;

        transform.Translate(dir.normalized * Time.deltaTime * speed);

        if(Vector3.Distance(transform.position, WPoints[wayIndex].transform.position)<0.3f)
        {
            if (wayIndex<WPoints.Count-1)
            {
                    wayIndex++;
            }
            else
            {
                Storm();
            }
        }
    }

    private void Storm()
    {
        if (castle != null)
        {
            castleScr.GetDamage(Damage);
        }
        Death();
    }

    public void Death()
    {
        System.Random rnd = new System.Random();
        spawner.GetComponent<EnimySpawner>().enimyLively--;
        castleScr.setMoney(rnd.Next(CoastMin,CoastMax));
        Destroy(gameObject);
        
    }
    public void GetDamage(float Damage)
    {
        HP -= Damage;
        if (HP<=0)
        {
            Death();
        }
    }
}
