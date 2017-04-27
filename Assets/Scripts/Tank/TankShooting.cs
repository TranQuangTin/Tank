using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public int m_PlayerNumber = 1;       
    public Rigidbody m_Shell;            
    public Transform m_FireTransform;    
    public Slider m_AimSlider;           
    public AudioSource m_ShootingAudio;  
    public AudioClip m_ChargingClip;     
    public AudioClip m_FireClip;         
    public float m_MinLaunchForce = 15f; 
    public float m_MaxLaunchForce = 30f; 
    public float m_MaxChargeTime = 0.75f;


    private string m_FireButton;         
    private float m_CurrentLaunchForce;  
    private float m_ChargeSpeed;         
    private bool m_Fired;
    public GameObject Shell;

    private void OnEnable()
    {
        //m_CurrentLaunchForce = m_MinLaunchForce;
        //m_AimSlider.value = m_MinLaunchForce;
    }


    private void Start()
    {
        m_FireButton = "Fire" + m_PlayerNumber;

        //m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }


    private void Update()
    {
        // Track the current state of the fire button and make decisions based on the current launch force.

        StartCoroutine(this.Shoot());
    }
    private bool CorountineActive = false;
    IEnumerator Shoot()
    {
        if (Input.GetAxis(m_FireButton) > 0)
        {
            if (!CorountineActive)
            {
                GameObject ChildShell = Instantiate(Shell, new Vector3(transform.localPosition.x, 1.6f, transform.localPosition.z), transform.localRotation);
                m_ShootingAudio.Play();
                ChildShell.GetComponent<ShellExplosion>().ParentColider = gameObject.GetComponent<Collider>();
                CorountineActive = true;
                yield return new WaitForSeconds(0.7f);
                CorountineActive = false;
            }
        }
    }

    private void Fire()
    {
        // Instantiate and launch the shell.
    }
}