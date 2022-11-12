using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health Item", menuName = "Items/Health")]
public class HealthItemObject : ItemObject
{
    public int healthRestoredValue;
    private void Awake()
    {
        type = ItemType.Default;
    }
}
