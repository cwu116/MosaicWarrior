using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public float time;
    public float cd;
    GameObject hotDog;
    GameObject drink;
    public Transform p1;
    public Transform p2;
    public Transform p3;
    public Transform p4;
    public Transform generatePoint;
    int loopCount;

    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        hotDog = (GameObject)Resources.Load("HotDog");
        drink = (GameObject)Resources.Load("Drink");
        loopCount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        GenerateItem();
    }

    void GenerateItem()
    {
        int num = Random.Range(0, 4);
        switch (num)
        {
            case 0:
                generatePoint = p1;
                break;
            case 1:
                generatePoint = p2;
                break;
            case 2:
                generatePoint = p3;
                break;
            case 3:
                generatePoint = p4;
                break;
        }
        GameObject Instance;
        int num1 = Random.Range(0, 3);
       
        
        
        if (time + cd < Time.time)
        {
            time = Time.time;
            if (num1 == 0)
            {

                if (generatePoint.GetComponentsInChildren<Transform>(true).Length <= 1)
                {
                    Instance = Instantiate(hotDog);
                    Instance.transform.SetParent(generatePoint);
                    Instance.transform.localPosition = new Vector3(0, 0, 0);

                }
                else
                {
                    if (loopCount > 0)
                    {
                        loopCount--;
                        GenerateItem();
                    }
                    else
                    {
                        loopCount = 10;
                    }
                }
            }
            else
            {
               
                if (generatePoint.GetComponentsInChildren<Transform>(true).Length <= 1)
                {
                    Instance = Instantiate(drink);
                    Instance.transform.SetParent(generatePoint);
                    Instance.transform.localPosition = new Vector3(0, 0, 0);

                }
                else
                {
                    if (loopCount > 0)
                    {
                        loopCount--;
                        GenerateItem();
                    }
                    else
                    {
                        loopCount = 10;
                    }
                }
            }

          
        }
    }
}
