using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    UIController controller;
    public bool p1Enter;
    public bool p2Enter;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.p1Confirm && controller.p2Confirm && p1Enter && p2Enter)
        {
            controller.StartGameNew();

        }
        if (Input.GetKey(KeyCode.F1) && !p1Enter)
        {
            p1Enter = true;
            controller.P1Select();
        }
        if (Input.GetKey(KeyCode.F2) && !p2Enter)
        {
            p2Enter = true;
            controller.p2Select();
        }
        if (p1Enter)
        {
            if (!controller.p1Confirm)
            {
                controller.p1SelectHelper();
            }
            if (!controller.p2Confirm)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    controller.P1ReselectRight();
                }
                if (Input.GetKey(KeyCode.A))
                {
                    controller.P1ReselectLeft();
                }
            }
            
            if (Input.GetKey(KeyCode.J))
            {
                controller.P1Confirm();
            }
        }
        if (p2Enter)
        {
            if (!controller.p2Confirm)
            {
                controller.p2SelectHelper();
            }

            if (!controller.p1Confirm)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    controller.P2ReselectLeft();
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    controller.P2ReselectRight();
                }
            }
            
            if (Input.GetKey(KeyCode.Keypad1))
            {
                controller.P2Confirm();
            }
        }
        

    
    }
}
