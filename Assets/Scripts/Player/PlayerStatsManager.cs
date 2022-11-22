using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    [SerializeField] public PlayerStats stats = null;
    // Start is called before the first frame update
    void Start()
    {
        stats.health = 100;
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
