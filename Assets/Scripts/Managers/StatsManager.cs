using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField] public Stats stats = null;
    [SerializeField] int health;
    [SerializeField] float timeInvincible = .25f;
    private Renderer mr;

    bool isInvincible;
    float invincibleTimer;
    
    //public ParticleSystem healEffect;
    //public ParticleSystem damageEffect;

    // Start is called before the first frame update
    void Start()
    {
        health = stats.health;
        mr = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) 
        {
            Destroy(gameObject);
        }

        if (isInvincible)
        {
            mr.material.color = new Color(1f,1f,1f);
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }
    public void TakeDamage(int damage)
    {
        if (isInvincible)
        {
            return;
        }
        isInvincible = true;
        invincibleTimer = timeInvincible;
        health -= damage;

    }
}
