using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catapultXX1 : MonoBehaviour
{
    public BoxCollider coll;
    CharacterController CC;
    CharacterController2 CC2;
    Rigidbody rig;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider>();

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);

        if (other.GetComponent<CharacterController>())
        {
            CC = other.GetComponent<CharacterController>();
            CC.CanInput = false;
            CC.Oldtime = Time.time;
        }

        if (other.GetComponent<CharacterController>() && other.CompareTag("Player2"))
        {
            CC2 = other.GetComponent<CharacterController2>();
            CC2.CanInput = false;
            CC2.Oldtime = Time.time;
        }

        rig = other.GetComponent<Rigidbody>();
        //Vector3 vel = rig.velocity;
        StartCoroutine(AddForce(1));
    }

    IEnumerator AddForce(float time)
    {
        var lasttime = Time.time;
        while (Time.time - lasttime < time)
        {
            rig.AddForce(-Speed, 0, 0);
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
