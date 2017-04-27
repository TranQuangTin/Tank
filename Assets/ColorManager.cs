using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour {
    public Color[] ListColor;
	// Use this for initialization
	void Awake () {
        ListColor = new Color[5];
        ListColor[0] = new Color(126/255f, 206 / 255f, 64 / 255f, 1);
        ListColor[1] = new Color(251 / 255f, 52 / 255f, 81 / 255f, 1);
        ListColor[2] = new Color(202 / 255f, 218 / 255f, 59 / 255f, 1);
        ListColor[3] = new Color(59 / 255f, 132 / 255f, 218 / 255f, 1);
        ListColor[4] = new Color(0, 0, 0, 1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
