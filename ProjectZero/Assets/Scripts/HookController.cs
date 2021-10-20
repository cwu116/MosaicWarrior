using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    public float speed;
    private float startTime;
    public float lifeTime;
    public GameObject Layer1;
    public GameObject Layer2;
    //public GameObject p1;
    //public GameObject p2;
    public CharacterController p1Control;
    public CharacterController2 p2Control;
    public CharacterAction p1Act;
    public CharacterAction p2Act;
    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        p1Control = GameObject.FindGameObjectWithTag("Player1").GetComponent<CharacterController>();
        p2Control = GameObject.FindGameObjectWithTag("Player2").GetComponent<CharacterController2>(); 
        p1Act = GameObject.FindGameObjectWithTag("Player1").GetComponent<CharacterAction>();
        p2Act = GameObject.FindGameObjectWithTag("Player2").GetComponent<CharacterAction>();

        startTime = Time.time;
        if(gameObject.tag == "Player1Hook")
        {
            //p1Control = p1.GetComponent<CharacterController>();
            p1Control.hasHook = true;
        }
        else if(gameObject.tag == "Player2Hook")
        {
            //p2Control = p2.GetComponent<CharacterController2>();
            p2Control.hasHook = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * transform.forward * Time.deltaTime;
        if(startTime + lifeTime < Time.time)
        {
            if (tag == "Player1Hook")
            {
                p1Control.hasHook = false;
            }
            else if (tag == "Player2Hook")
            {
                p2Control.hasHook = false;
            }
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(this.CompareTag("Player1Hook") && other.CompareTag("Player2")){
            p1Control.hasHook = false;
            FakeToTrue1();
            p1Act.Brush();
            Destroy(this.gameObject);
        }
        else if (this.CompareTag("Player2Hook") && other.CompareTag("Player1"))
        {
            p2Control.hasHook = false;
            FakeToTrue2();
            p2Act.Brush();
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Rock"))
        {
            Destroy(this.gameObject);

        }


    }



    public void FakeToTrue1()
    {
        Layer1 = GameObject.FindWithTag("Layer1");
        CubeManager[] children = Layer1.GetComponentsInChildren<CubeManager>();
        foreach (CubeManager cube in children)
        {
            if (cube.state == CubeManager.State.FakeP1)
            {
                cube.state = CubeManager.State.Default;
            }
        }

        Layer2 = GameObject.FindWithTag("Layer2");
        CubeManager[] children2 = Layer2.GetComponentsInChildren<CubeManager>();
        foreach (CubeManager cube in children2)
        {
            if (cube.state == CubeManager.State.FakeP1)
            {
                cube.state = CubeManager.State.TrueP1;
                cube.belong = CubeManager.Belong.Player1;
            }
        }
        GameManager manager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        manager.CheckCount();
    }

    public void FakeToTrue2()
    {
        Layer1 = GameObject.FindWithTag("Layer1");
        CubeManager[] children = Layer1.GetComponentsInChildren<CubeManager>();
        foreach (CubeManager cube in children)
        {
            if (cube.state == CubeManager.State.FakeP2)
            {
                cube.state = CubeManager.State.Default;
            }
        }

        Layer2 = GameObject.FindWithTag("Layer2");
        CubeManager[] children2 = Layer2.GetComponentsInChildren<CubeManager>();
        foreach (CubeManager cube in children2)
        {
            if (cube.state == CubeManager.State.FakeP2)
            {
                cube.state = CubeManager.State.TrueP2;
                cube.belong = CubeManager.Belong.Player2;
            }
        }
        GameManager manager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        manager.CheckCount();
    }
}
