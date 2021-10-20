using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform player;
    Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = transform.position - player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.position + temp;
    }
}
