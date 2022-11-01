using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private Vector2 mousePosition;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDir = mousePosition - new Vector2(this.transform.position.x, this.transform.position.y);;
        Debug.DrawLine(this.transform.position,mousePosition);
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;

        this.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
