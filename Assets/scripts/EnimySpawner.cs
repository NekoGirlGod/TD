using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnimySpawner : MonoBehaviour
{
    public List<GameObject> typsEnimy = new List<GameObject>();
    public float WaveCD;
    public float EnimyCD;
    public int[] EnimyInWave;
    public GameObject Castle;
    public GameObject TMProWave;

    TextMeshProUGUI waveText;
    int typsEnimyCount;
    private int thisWave=0;
    int WaveCount;
    GameObject mob;
    [System.NonSerialized]
    public int enimyLively = 0;
    System.Random rnd = new System.Random();
    void Start()
    {
        waveText= TMProWave.GetComponent<TextMeshProUGUI>();
        typsEnimyCount = typsEnimy.Count;
        WaveCount = EnimyInWave.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(enimyLively<=0)
        {
            StartCoroutine(WaveStart());
        }
    }
    IEnumerator WaveStart()
    {
        if (thisWave < WaveCount)
        {
            enimyLively = EnimyInWave[thisWave];
            textUpd(thisWave, WaveCount);
            yield return new WaitForSeconds(WaveCD);
            StartCoroutine(EnimySpawn());

        }
        else
        {
            textUpd(thisWave, WaveCount);
            Win();
        }

    }

    private void Win()
    {
       
    }

    IEnumerator EnimySpawn()
    {
        if (EnimyInWave[thisWave] > 0)
        {
            yield return new WaitForSeconds(EnimyCD);
            EnimyInWave[thisWave]--;
            mob = Instantiate(typsEnimy[rnd.Next(typsEnimyCount)], transform.position, Quaternion.identity);
            Enimy enimyScr = mob.GetComponent<Enimy>();
            enimyScr.castle = Castle;
            enimyScr.spawner = gameObject;
            StartCoroutine(EnimySpawn());
        }
        else
        {
            thisWave++;
        }
    }

    void textUpd(int thisWave, int allWave)
    {
        waveText.text = thisWave.ToString() + "/" + allWave.ToString();
    }
}
