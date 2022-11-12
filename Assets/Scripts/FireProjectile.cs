using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private Rigidbody2D rb;
    private float Timer;
    // Start is called before the first frame update
    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Timer = 0f;
        rb.velocity = transform.right * speed;
    }
    private void FixedUpdate()
    {
        Timer += Time.deltaTime;
        if (Timer > 5) 
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.layer.ToString());
        if (collision.gameObject.layer.ToString().Equals("0"))
        {
            Destroy(this.gameObject);

        }
    }
    public float GetDamage() 
    {
        return damage;
    }
}
