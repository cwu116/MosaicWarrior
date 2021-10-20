using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CountDown : MonoBehaviour
{
    public float timer;
    private Text text;
    private Animator anim;
    public bool countOver;
    public GameManager manager;
    public DataTrans trans;
    void Start()
    {
        timer = 150.0f;
        text = GetComponent<Text>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer - Time.fixedTime <= 10)
        {
            anim.enabled = true;
        }
        if(timer- Time.fixedTime <= 0)
        {
            countOver = true;
            text.text = "游戏结束";
            anim.enabled = false;
            if(manager .p1Count > manager.p2Count)
            {
                trans.Player1Win = true;
            }
            else
            {
                trans.Player1Win = false;
            }
            SceneManager.LoadScene(2);

        }
        else
        {
            text.text = "剩余时间\n" + Mathf.FloorToInt(timer - Time.fixedTime);
        }
        
    }

}
