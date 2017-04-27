using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winner : MonoBehaviour {

	// Use this for initialization
	void Start () {
        try
        {
            gameObject.GetComponent<Text>().text = "Player " + (PlayerPrefs.GetInt("TankWon")+1) + " won!";
        }catch { }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
