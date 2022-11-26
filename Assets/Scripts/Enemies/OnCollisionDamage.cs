using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionDamage : MonoBehaviour
{

    private float timer;
    [SerializeField] int damage;
    [SerializeField] float attackTimer;
    [SerializeField] string targetTag;
    private bool hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > attackTimer)
        {
            timer = 0;
            hit = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag) && hit == false) 
        {
            //minus health
            collision.gameObject.GetComponent<StatsManager>().TakeDamage(damage);
            hit = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag) && hit == false)
        {

            //minus health
            collision.gameObject.GetComponent<StatsManager>().TakeDamage(damage);
            hit = true;
        }
    }
}
