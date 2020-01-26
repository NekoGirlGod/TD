using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour, IPointerDownHandler
{
    [System.NonSerialized]
    public int towerType;
    [System.NonSerialized]
    public GameObject slot;
    [System.NonSerialized]
    public int towerCost;
    [System.NonSerialized]
    public Castle castleScr;

    public Text price;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (towerCost <= castleScr.Money)
        {
            slot.GetComponent<towerSlot>().InstantiateTower(towerType);
            castleScr.setMoney(-towerCost);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        price.text = towerCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
