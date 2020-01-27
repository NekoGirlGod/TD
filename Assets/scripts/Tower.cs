using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bulletType;
    public float cooldown=1.3f;
    public float radius=3f;
    public int cost=100; 

    List<GameObject> Enimes;
    void Start()
    {
        Enimes = new List<GameObject>();
        StartCoroutine(Shoot());
        gameObject.GetComponent<CircleCollider2D>().radius = radius;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(cooldown);

        if (Enimes.Count > 0)
        {
            GameObject Target = Enimes[0];
            GameObject bullet = Instantiate(bulletType, gameObject.transform.position,Quaternion.identity);
            bullet.GetComponent<bullet>().setTarget(Target);
        }

        StartCoroutine(Shoot());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enimy")
        {
            Enimes.Add(other.gameObject);
        }
    }

      void OnTriggerExit2D(Collider2D other)
      {
          if (other.gameObject.tag == "Enimy")
          {
            Enimes.Remove(other.gameObject);
          }
      }
}
