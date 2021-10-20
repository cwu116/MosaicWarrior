using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Layer1;
    public GameObject Layer2;
    public int playerNumber;
    public GameManager manager;
    public float hp;
    public CharacterAction act;
 
    

  

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("TrueLayer"))
        {
            CubeManager manager = other.GetComponent<CubeManager>();
            if (playerNumber == 1 && manager.belong == CubeManager.Belong.Player2)
            {
                if (hp > 0)
                    hp -= 1 * Time.deltaTime;
            }


            else if (playerNumber == 2 && manager.belong == CubeManager.Belong.Player1)
            {
                if (hp > 0)
                    hp -= 1 * Time.deltaTime;
            }
        }
    }

 

  

    
}
