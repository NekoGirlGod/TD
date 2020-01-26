using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower Data", menuName = "Tower Data", order = 51)]
public class TowerData : ScriptableObject
{
    [SerializeField]
    public GameObject bulletType;
    [SerializeField]
    public float cooldown = 1.3f;
    [SerializeField]
    public float radius = 3f;
    [SerializeField]
    public int cost = 100;

}
