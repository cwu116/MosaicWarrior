using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    enum PlayerColor
    {
        Yellow,
        Blue,
    }
    Vector3 posCam;
    Vector3 rotCam;
    private int yellowPlayer;
    private int bluePlayer;
    public Camera Cam;
    Vector3 Pos1;
    Vector3 Pos2;
    Vector3 Pos1Right;
    Vector3 Pos2Left;
    Vector3 mainCam;
    public GameObject pointer_p1;
    public GameObject pointer_p2;
    public GameObject rule_p1;
    public GameObject rule_p2;
    public GameObject confirm_p1;
    public GameObject confirm_p2;
    public Text countDownText;
    PlayerColor p1;
    PlayerColor p2;
    public bool p1Confirm;
    public bool p2Confirm;
    
    private void Start()
    {
        p1 = PlayerColor.Blue;
        p2 = PlayerColor.Yellow;
        Pos1 = new Vector3(pointer_p1.transform.position.x, pointer_p1.transform.position.y, pointer_p1.transform.position.z);
        Pos2 = new Vector3(pointer_p2.transform.position.x, pointer_p2.transform.position.y, pointer_p2.transform.position.z);
        Pos1Right = new Vector3(Pos1.x + 80, Pos1.y, Pos1.z);
        Pos2Left = new Vector3(Pos2.x - 80, Pos2.y, Pos2.z);
        posCam = new Vector3(-4.59f, 1.43f, 14.54f);
        rotCam = new Vector3(1.67f, -274.5f, 2.04f);
        mainCam = Camera.main.transform.position;
    }

    public void StartGameNew()
    {
        SceneManager.LoadScene(1);
    }

    public void P1Select()
    {
        Debug.Log("player1 method has entered");
        pointer_p1.SetActive(true);
    }

    public void p1SelectHelper()
    {
        rule_p1.GetComponentInChildren<Text>().text = "<b>Player1</b> <i>按下<b>J</b>确认</i>";
    }
    public void P1Confirm()
    {
            Text t = confirm_p1.GetComponent<Text>();
            switch (p1)
            {
                case PlayerColor.Blue:
                    t.color = Color.blue;
                    bluePlayer = 1;
                    yellowPlayer = 2;
                    pointer_p2.transform.position = Pos2;
                    break;
                case PlayerColor.Yellow:
                    t.color = Color.yellow;
                    yellowPlayer = 1;
                    bluePlayer = 2;
                    pointer_p2.transform.position = Pos1Right;
                    break;
            }
            p1Confirm = true;
            rule_p1.SetActive(false);
            confirm_p1.SetActive(true);
            pointer_p1.SetActive(true);
    }

    public void P2Confirm()
    {
            Text t = confirm_p2.GetComponent<Text>();
            switch (p2)
            {
                case PlayerColor.Blue:
                    t.color = Color.blue;
                    bluePlayer = 2;
                    pointer_p1.transform.position = Pos2Left;
                    break;
                case PlayerColor.Yellow:
                    t.color = Color.yellow;
                    yellowPlayer = 2;
                    pointer_p1.transform.position = Pos1;
                    break;
            }
            p2Confirm = true;
            rule_p2.SetActive(false);
            confirm_p2.SetActive(true);
            pointer_p2.SetActive(true);
    }
    public void P1ReselectRight()
    {
       pointer_p1.transform.position = Pos2Left;
       p1 = PlayerColor.Yellow;
    }

    public void P1ReselectLeft()
    {
        pointer_p1.transform.position = Pos1;
        p1 = PlayerColor.Blue;
    }

    public void P2ReselectRight()
    {
        pointer_p2.transform.position = Pos2;
        p2 = PlayerColor.Yellow;
    }

    public void P2ReselectLeft()
    {
        pointer_p2.transform.position = Pos1Right;
        p2 = PlayerColor.Blue;
    }

    public void p2Select()
    {
        pointer_p2.SetActive(true);
    }
    public void p2SelectHelper()
    {
        rule_p2.GetComponentInChildren<Text>().text = "<b>Player1</b> <i>按下<b>小键盘 1</b>确认</i>";
    }

    public void StartGame()
    {
  //      SceneManager.LoadScene(1);
        Cam.transform.DOMove(posCam, 1.5f);
        Cam.transform.DORotate(rotCam, 1.5f);
        Debug.Log("start a new scene");
    }
    public void BackToMain()
    {
        Vector3 back_pos = new Vector3(-3.64f, 4.52f, 11.05f);
        Vector3 back_rot = new Vector3(13f, 163, 2.11f);

        Cam.transform.DOMove(back_pos, 1.5f);
        Cam.transform.DORotate(back_rot, 1.5f);
    }
    public void GameSettings()
    {
        Debug.Log("enter game settings menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
