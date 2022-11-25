using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Stats", menuName = "Stats/NewStats")]
public class Stats : ScriptableObject
{
    public int health;

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
