

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    CharacterAction act;
    private float h1;
    public int id;
    public bool hasHook;
    private float v1;
    private Vector3 input;
    public bool CanInput;
    public float NomoveCD = 1;
    public float Oldtime;
    // Start is called before the first frame update
    void Start()
    {
        act = GetComponent<CharacterAction>();
        id = 1;
        CanInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (act.hp <= 0)
        {
            act.Die();
        }
        if (act.isDead)
        {
            return;
        }
        if (Time.time > Oldtime + NomoveCD)
        {
            CanInput = true;
        }
        if (!CanInput)
        {
            return;
        }
        if (!act.isTargeting)
        {
                h1 = Input.GetAxis("Horizontal");
                v1 = Input.GetAxis("Vertical");
            input = new Vector3(h1, 0, v1);
            act.MoveAct(input); 
            act.MoveAnim(h1, v1);
            
        }

        if (act.energy <= 0)
        {
            act.brush.SetActive(false);
        }

        if (Input.GetKey(KeyCode.J)&&!act.hasShot)//瞄准&&!hasHook
        {
            act.MoveAnim(0, 0);
            
            if (Input.GetKey(KeyCode.K))//发射
            {
                act.AttackAnim();
                act.AttackAct(id);
                act.isTargeting = false;
                
            }
            else
            {
                act.isTargeting = true;
                act.Targeting();
            }
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            act.isTargeting = false;
            act.CancelTargeting();
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            act.Brush();
        }

        
    }
}
