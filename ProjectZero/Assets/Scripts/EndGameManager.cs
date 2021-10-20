using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndGameManager : MonoBehaviour
{
    DataTrans trans;
    public Animator p1;
    public Animator p2;
    public Text p1text;
    public Text p2text;

    // Start is called before the first frame update
    void Start()
    {
        trans = GameObject.FindGameObjectWithTag("Data").GetComponent<DataTrans>();
        p1text = GameObject.Find("P1Text").GetComponent<Text>();
        p2text = GameObject.Find("P2Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trans.Player1Win)
        {
            p1.SetBool("Player1Win", true);
            p2.SetBool("Player1Win", true);
            p1text.enabled = true;
        }
        else
        {
            p1.SetBool("Player1Win", false);
            p2.SetBool("Player1Win", false);
            p2text.enabled = true;
        }
    }
}
