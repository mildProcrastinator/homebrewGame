using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Item", menuName = "Items/Default")]
public class DefaultItemObject : ItemObject
{
    private void Awake()
    {
        type = ItemType.Default;
    }
}
