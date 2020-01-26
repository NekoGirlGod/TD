using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class towerSlot : MonoBehaviour,IPointerDownHandler
{
    public List<GameObject> towerType=new List<GameObject>();
    public GameObject castle;
    public float rayLenght = 1;
    public GameObject Towerbutton;
    
    GameObject canvas;
    bool towerExists = false;
    bool buttonsActiv = false;
    GameObject tower;
    Castle castleScr;
    GameObject[] towerPrewiew;
    GameObject[] buttons;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!towerExists)
        {
            if(!buttonsActiv)
            TowerChoise();
        }
        else
        {
            Tower towerScr = tower.GetComponent<Tower>();
            castleScr.setMoney(towerScr.cost*3/4);
            Destroy(tower);
            towerExists = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        castleScr = castle.GetComponent<Castle>();

        canvas = transform.parent.gameObject;

        towerPrewiew = new GameObject[towerType.Count];
        for (int i = 0; i < towerPrewiew.Length; i++)
        {
            towerPrewiew[i] = Towerbutton;
           // var prewiewImg = towerPrewiew[i].GetComponent<Image>();
           // var towerSR = towerType[i].GetComponent<SpriteRenderer>();
           // prewiewImg.sprite = towerSR.sprite;
           // prewiewImg.color = towerSR.color;
        }
        DeployButtons();
    }
    

    // Update is called once per frame
    void Update()
    {
    }

    void TowerChoise()
    {
        buttonsActiv = true;
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }
    }

    private void DeployButtons()
    {
        int typeTowerCount = towerType.Count;
        Vector3[] rays = ReysPosition(typeTowerCount);

        buttons = new GameObject[typeTowerCount];
        for (int i = 0; i < typeTowerCount; i++)
        {
            Vector3 position = transform.position + rays[i] * rayLenght;
            buttons[i] = Instantiate(towerPrewiew[i]) as GameObject;
            buttons[i].transform.SetParent(canvas.transform, false);
            buttons[i].transform.position = position;
            var TowButtonScr = buttons[i].GetComponent<TowerButton>();
            TowButtonScr.towerType = i;
            TowButtonScr.slot = gameObject;
            TowButtonScr.towerCost = towerType[i].GetComponent<Tower>().cost;
            TowButtonScr.castleScr = castleScr;
            buttons[i].SetActive(false);
        }
    }

    public void InstantiateTower(int towerIndex)
    {
        tower = Instantiate(towerType[towerIndex], transform.position, Quaternion.identity);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
        buttonsActiv = false;
        towerExists = true;
    }
    private static Vector3[] ReysPosition(int typeTowerCount)
    {
        float angle = 360 / typeTowerCount;
        var rays = new Vector3[typeTowerCount];
        for (int i = 0; i < typeTowerCount; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle * i);
            float y = Mathf.Cos(Mathf.Deg2Rad * angle * i);
            rays[i] = new Vector3(x, y, 0);
        }

        return rays;
    }
}
