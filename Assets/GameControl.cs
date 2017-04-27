using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject Tank;
    public CameraControl CameraRig;
    //public static GameControl Global;
    [Range(0, 5)]
    public int numberTank;
    public PositionManager Position;
    public ColorManager Colors;
    public Transform[] ListTankTransform;
    public GameObject Point;

    //private void Awake()
    //{
    //    Global = this;
    //}

    // Use this for initialization
    void Start()
    {
        numberTank = PlayerPrefs.GetInt("abc");
        ListTankTransform = new Transform[numberTank];
        CameraRig.m_Targets = new Transform[numberTank];
        for (int i = 0; i < numberTank; i++)
        {
            GameObject gg = Instantiate(Tank, Position.ListPosition[i], Quaternion.Euler(0, 0, 0));
            gg.gameObject.GetComponent<TankMovement>().m_PlayerNumber = i;
            gg.gameObject.GetComponent<TankShooting>().m_PlayerNumber = i;

            MeshRenderer[] Temp = gg.gameObject.GetComponentsInChildren<MeshRenderer>();
            for (int j = 0; j < Temp.Length-1; j++)
            {
                    Temp[j].material.color = Colors.ListColor[i];
            }
            CameraRig.m_Targets[i] = gg.transform;
            ListTankTransform[i] = gg.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        CheckWinner();
        StartCoroutine(this.NewPoint());
    }
    public void CheckWinner()
    {
        int NumTankRemain = 0;
        for (int i = 0; i < numberTank; i++)
        {
            try
            {
                if (ListTankTransform[i].gameObject.activeSelf) NumTankRemain++;
            }
            catch { }
        }
        if (NumTankRemain <= 1)
        {
            for (int i = 0; i < numberTank; i++)
            {
                try
                {
                    if (ListTankTransform[i].gameObject.activeSelf) PlayerPrefs.SetInt("TankWon", i);
                }
                catch { }
            }
            StartCoroutine(this.GameOver());
        }
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    private bool NewOrNot = false;
    IEnumerator NewPoint()
    {
        if (!NewOrNot)
        {
            Instantiate(Point, RandPosition(), transform.rotation);
            NewOrNot = true;
            yield return new WaitForSeconds(10);
            NewOrNot = false;
        }
    }
    private Vector3 RandPosition()
    {
        Vector3 position = new Vector3();
        position.x = Random.Range(-31, 44);
        position.z = Random.Range(-39, 47);
        position.y = 1;
        return position;
    }
}
