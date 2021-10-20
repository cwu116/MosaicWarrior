using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTrans : MonoBehaviour
{
    // Start is called before the first frame update
    public static DataTrans dataTrans = null;
    public bool Player1Win;
    void Start()
    {
        dataTrans = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    
}
