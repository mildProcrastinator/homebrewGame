using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerManager : MonoBehaviour
{
    public InputController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = ScriptableObject.CreateInstance<AIController>();
    }
}
