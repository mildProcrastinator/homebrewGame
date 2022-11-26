using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerManager : MonoBehaviour
{
    public InputController controller;
    // Start is called before the first frame update
    void Awake()
    {
        if (this.gameObject.name.Contains("Skeleton"))
        {
            controller = ScriptableObject.CreateInstance<AIController>();
        }
        else 
        {
            controller = ScriptableObject.CreateInstance<BatController>();
        }
        
    }
}
