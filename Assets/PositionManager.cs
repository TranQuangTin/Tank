using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour {

    public Vector3[] ListPosition;
    // Use this for initialization
    void Start() {
        ListPosition = new Vector3[5];
        ListPosition[0] = new Vector3(-30, 0, -7);
        ListPosition[1] = new Vector3(-30, 0, 12);
        ListPosition[2] = new Vector3(-30, 0, 39);
        ListPosition[3] = new Vector3(29, 0, 39);
        ListPosition[4] = new Vector3(-9, 0, 39);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
