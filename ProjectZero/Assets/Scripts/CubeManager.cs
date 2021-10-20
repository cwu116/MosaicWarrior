using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int row;
    public int col;
    public State state;
    public bool truefalseState;
    public Belong belong;

    public enum State
    {
        FakeP1,
        TrueP1,
        FakeP2,
        TrueP2,
        Default
    }

    public enum Belong
    {
        Player1,
        Player2,
        Default
    }

  
}
