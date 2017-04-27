using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAgaint : MonoBehaviour {
    public Button btn;
	// Use this for initialization
	void Start () {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(KeepPlay);
	}
	
	// Update is called once per frame
	void KeepPlay () {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}
}
