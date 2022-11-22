using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    [SerializeField] private InventoryObject inventory = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var item = collision.gameObject.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.GetItem(), 1);
            Destroy(collision.gameObject);
        }
    }
    private void OnApplicationQuit()
    {
        inventory.inventory.Clear();
    }
}
