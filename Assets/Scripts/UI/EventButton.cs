using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventButton : MonoBehaviour {
    public static int NumberofTank;
    public Button Playbtn;
    // Use this for initialization
    void Start () {
        Playbtn = gameObject.GetComponent<Button>();
        Playbtn.onClick.AddListener(ChangeSence);
        }
    
	
	// Update is called once per frame
	void Update () {

    }
    public void ChangeSence()
    {
        PlayerPrefs.SetInt("abc", NumberofTank);
        Debug.Log(NumberofTank);
        SceneManager.LoadScene(1);
    }
}
