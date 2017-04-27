using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

	// Use this for initialization
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(new Vector3(45, 45, 45));
	}
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<TankHealth>().m_CurrentHealth = 100;
        other.gameObject.GetComponent<TankHealth>().TakeDamage(0);
        Destroy(gameObject);
    }
}
