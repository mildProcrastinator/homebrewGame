using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public StatsManager playerStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<StatsManager>();
    }
    // Update is called once per frame
    void Update()
    {
        healthBar.value = playerStats.GetHealth();
    }
}
