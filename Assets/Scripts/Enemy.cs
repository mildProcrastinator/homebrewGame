using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Enemy : MonoBehaviour
{
    public EnemyObject enemyType;
    // Start is called before the first frame update
    void Start()
    {
        enemyType.GetComponents(this.gameObject.GetComponent<Ground>(),  this.gameObject.GetComponent<Seeker>(), this.gameObject.GetComponent<Rigidbody2D>());
    }

    // Update is called once per frame
    void Update()
    { 
        enemyType.UpdatePath();
    }
    private void FixedUpdate()
    {
        enemyType.FixedUpdatePath();
    }
    private void SetValues()
    {
        
    }
}
