using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeClick : MonoBehaviour {
    public Button btn;
	// Use this for initialization
	void Start () {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TurnBackHome);
	}
	
	// Update is called once per frame
	void TurnBackHome () {
        Debug.Log("chay");
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
}
