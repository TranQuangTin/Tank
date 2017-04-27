using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownEvent : MonoBehaviour
{
    public Dropdown DropdownNumber;
    public int NumberofTank;
    // Use this for initialization
    void Start()
    {
        DropdownNumber = gameObject.GetComponent<Dropdown>();
        NumberofTank = System.Convert.ToInt32(DropdownNumber.options[DropdownNumber.value].text);
        Debug.Log(PlayerPrefs.GetInt("abc"));
    }

    // Update is called once per frame
    public void ChangeNumberoftank(int value)
    {
        NumberofTank = System.Convert.ToInt32(DropdownNumber.options[value].text);
    }
    public void PlayClick()
    {
        PlayerPrefs.SetInt("abc", NumberofTank);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
