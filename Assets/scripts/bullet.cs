using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    
    public float speed = 10;
    public float Damage = 40;
    
    GameObject Target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void setTarget(GameObject enemy)
    {
        Target = enemy;
    }

    private void Move()
    {
        if (Target != null)
        {
            if (Vector2.Distance(transform.position, Target.transform.position) < 0.1f)
            {
                Target.GetComponent<Enimy>().GetDamage(Damage);
                Destroy(gameObject);
            }
            else
            {
                Vector2 dir = Target.transform.position - transform.position;
                transform.Translate(dir.normalized * Time.deltaTime * speed);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
