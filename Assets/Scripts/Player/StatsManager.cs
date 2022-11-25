using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField] public Stats stats = null;
    [SerializeField, Range(0f, 100f)] int startingHealth;
    // Start is called before the first frame update
    void Start()
    {
        stats.health = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.health <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
