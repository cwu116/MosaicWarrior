using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    DataTrans trans;
    public Animator p1;
    public Animator p2;
    // Start is called before the first frame update
    void Start()
    {
        trans = GameObject.FindGameObjectWithTag("Data").GetComponent<DataTrans>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trans.Player1Win)
        {
            p1.SetBool("Player1Win", true);
            p2.SetBool("Player1Win", true);
        }
        else
        {
            p1.SetBool("Player1Win", false);
            p2.SetBool("Player1Win", false);
        }
    }
}
