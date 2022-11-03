using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField] private Animator animator = null;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayer;
    private float direction;
    private bool flippedDirection = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (input.RetreiveShootInput())
        {
            //Melee
            //Attack();
            RealAttack();
        }
    }

    void RealAttack()
    {
        //Attack by transforming weapon GameObject
        animator.SetTrigger("Attack");
    }

    void Attack() 
    {
        //draw collider sphere version
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies) 
        {
            Debug.Log("HIT: " + enemy.name);
        }
    }
    /**private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }**/
}
