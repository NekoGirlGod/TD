using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScr : MonoBehaviour
{
    public List<GameObject> WayPoints = new List<GameObject>();
    public GameObject way;
    void Start()
    {
        foreach (Transform child in way.GetComponentsInChildren<Transform>())
        {
            WayPoints.Add(child.gameObject);
        }
        WayPoints.RemoveAt(0);
    }


    void Update()
    {
        
    }

    

}
