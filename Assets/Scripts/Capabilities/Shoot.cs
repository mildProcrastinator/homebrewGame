using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField] private int _ammoCapacity = 99;
    [SerializeField, Range(0, 12)] private int _gunCapacity = 4;
    [SerializeField, Range(0f, 12f)] private float _reloadSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float _fireRate = 4f;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject firingPoint;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputController>();
        projectile = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(input.RetreiveShootInput()) 
        {
            //shoot
            Instantiate(projectile, firingPoint.transform.position, firingPoint.transform.rotation);
        }
    }
}
