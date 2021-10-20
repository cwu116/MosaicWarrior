using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int r, c;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject env;
    public GameObject env1;
    public Player player1;
    public Player player2;
    public DataTrans trans;
    public GameObject Layer1;
    public CubeManager[] children;
    public GameObject Layer2;
    public CubeManager[] children2;
    public Material Default;
    public Material P1;
    public Material P1True;
    public Material P2;
    public Material P2True;
    public Text text;
    public float p1Count;
    public float p2Count;
    public float num;
    public Image image;
    public Image imageTop;
    private void Awake()
    {

        CreateFakeLayer(new Vector3(0.6f, 0.02f, 0.5f), env, prefab1);
        env.tag = "Layer1";
        CreateTrueLayer(new Vector3(0.6f, 0.01f, 0.5f), env1, prefab2);
        env1.tag = "Layer2";
    }
    void Start()
    {
        Layer1 =  GameObject.FindWithTag("Layer1");
        children = Layer1.GetComponentsInChildren<CubeManager>();
        Layer2 =  GameObject.FindWithTag("Layer2");
        children2 = Layer2.GetComponentsInChildren<CubeManager>();
    }

    void CheckGameOver()
    {
        if(player1.hp <= 0)
        {
            trans.Player1Win = false;
            SceneManager.LoadScene(2);
            
        }
        else if (player2.hp <= 0)
        {
            trans.Player1Win = true;
            SceneManager.LoadScene(2);
        }

    }
    private void CreateFakeLayer(Vector3 v3, GameObject env, GameObject prefab)
    {
        GameObject go;
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                go = Instantiate(prefab, env.transform);
                go.transform.position = new Vector3(-15 + i, 0, -15 + j);
                CubeManager cube = go.GetComponent<CubeManager>();
                cube.GetComponent<MeshRenderer>().material = Default;
                cube.state = CubeManager.State.Default;
                cube.gameObject.layer = 8;
                cube.belong = CubeManager.Belong.Default;
                cube.row = i;
                cube.col = j;
            }
        }

        env.transform.position = new Vector3(v3.x, v3.y, v3.z);         
    }   
    
    private void CreateTrueLayer(Vector3 v3, GameObject env, GameObject prefab)
    {
        GameObject go;
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                go = Instantiate(prefab, env.transform);
                go.transform.position = new Vector3(-15 + i, 0, -15 + j);
                CubeManager cube = go.GetComponent<CubeManager>();
                cube.GetComponent<MeshRenderer>().material = Default;
                cube.state = CubeManager.State.Default;
                cube.belong = CubeManager.Belong.Default;
                cube.gameObject.layer = 9;
                cube.row = i;
                cube.col = j;
            }
        }

        env.transform.position = new Vector3(v3.x, v3.y, v3.z);         
    }

    public void CheckCount()
    {
        p1Count = 0;
        p2Count = 0;
        foreach (CubeManager cube in children2)
        {

            if (cube.state == CubeManager.State.TrueP1)
            {

                p1Count++;

            }

            if (cube.state == CubeManager.State.TrueP2)
            {

                p2Count++;

            }

        }

        num= p1Count / (p1Count + p2Count);
        image.fillAmount = num;
        imageTop.enabled = false;
        Debug.Log(p1Count + "p1"); 
        Debug.Log(p2Count + "p2");
        Debug.Log(num + "num");
    }



    // Update is called once per frame
    void Update()
    {

        CheckGameOver();
        foreach (CubeManager cube in children)
        {
            if (cube.state == CubeManager.State.Default)
            {
                cube.GetComponent<MeshRenderer>().enabled = false;
            }

            if (cube.state == CubeManager.State.FakeP1)
            {
                cube.GetComponent<MeshRenderer>().enabled = true;
                cube.GetComponent<MeshRenderer>().material = P1;
                
            }

            if (cube.state == CubeManager.State.FakeP2)
            {
                cube.GetComponent<MeshRenderer>().enabled = true;
                cube.GetComponent<MeshRenderer>().material = P2;

            }          

        }  
        
        foreach (CubeManager cube in children2)
        {

            if (cube.state == CubeManager.State.TrueP1)
            {
                
                    cube.GetComponent<MeshRenderer>().material= P1True;
                
            }
            
            if (cube.state == CubeManager.State.TrueP2)
            {

                cube.GetComponent<MeshRenderer>().material = P2True;
                
            }
            
        }     
    }
}
