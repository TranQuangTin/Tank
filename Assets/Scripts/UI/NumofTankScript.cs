using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumofTankScript : MonoBehaviour {
    public static int NumTank = 2;
    // Use this for initialization
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
