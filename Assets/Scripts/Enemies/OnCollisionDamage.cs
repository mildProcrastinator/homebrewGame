using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionDamage : MonoBehaviour
{

    private float timer;
    [SerializeField] float attackTimer;
    [SerializeField] public Stats targetStats = null;
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
        if (collision.gameObject.CompareTag("Player") && hit == false) 
        {
            //minus health
            targetStats.TakeDamage(10);
            hit = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && hit == false)
        {

            //minus health
            targetStats.TakeDamage(10);
            hit = true;
        }
    }
}
