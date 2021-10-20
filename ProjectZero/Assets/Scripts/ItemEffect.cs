using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if((other.CompareTag("P1Hp") || other.CompareTag("P2Hp")) && this.CompareTag("HotDog"))
        {
            float hp = other.GetComponent<Player>().hp;
            if(hp < 80)
            {
                other.GetComponent<Player>().hp += 20;
            }
            else
            {
                other.GetComponent<Player>().hp = 100;
            }
            Destroy(gameObject);
        }
        
        if ((other.CompareTag("Player1") || other.CompareTag("Player2")) && this.CompareTag("Drink"))
        {
          
            other.GetComponent<CharacterAction>().energy = 100;
            Destroy(gameObject);           
        }
    }
}
