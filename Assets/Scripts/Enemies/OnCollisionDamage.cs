using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionDamage : MonoBehaviour
{

    private float timer;
    [SerializeField] int damage;
    [SerializeField] string targetTag;
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

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag)) 
        {
            //minus health
            collision.gameObject.GetComponent<StatsManager>().TakeDamage(damage);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {

            //minus health
            collision.gameObject.GetComponent<StatsManager>().TakeDamage(damage);
        }
    }
}
