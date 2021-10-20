using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Rigidbody Rig;
    public float Speed; 
    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion y = Quaternion.Euler(0, Speed*Time.fixedDeltaTime, 0);
        Rig.transform.rotation = y* Rig.transform.rotation;
    }
}
