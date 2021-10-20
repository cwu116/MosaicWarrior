using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion y = Quaternion.Euler(0, Speed, 0);
        transform.rotation = y * transform.rotation;
    }
}
