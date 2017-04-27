using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public int m_PlayerNumber = 1;         
    public float m_Speed = 0.1f;            
    public float m_TurnSpeed = 180f;       
    public AudioSource m_Idling;   
    public AudioSource m_EngineDriving;      
    public float m_PitchRange = 0.2f;

    
    private string m_MovementAxisName;     
    private string m_TurnAxisName;         
    private Rigidbody m_Rigidbody;         
    private float m_MovementInputValue;    
    private float m_TurnInputValue;        
    private float m_OriginalPitch;


    public Vector3 PositionNow;
    private Quaternion RotationNow;
    private AudioSource m_EngineDriving1;
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void OnEnable ()
    {
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }


    private void OnDisable ()
    {
        m_Rigidbody.isKinematic = true;
    }


    private void Start()
    {
        m_MovementAxisName = "Vertical" + m_PlayerNumber;
        m_TurnAxisName = "Horizontal" + m_PlayerNumber;
    }
    

    private void Update()
    {
        ////Debug.Log(Time.deltaTime);
        //AudioSource.PlayClipAtPoint(m_EngineIdling,PositionNow);
        Move();
        
    }


    private void EngineAudio()
    {
        // Play the correct audio clip based on whether or not the tank is moving and what audio is currently playing.
        if (m_Idling.isPlaying)
        {
            m_Idling.Pause();
            if (!m_EngineDriving.isPlaying)
                m_EngineDriving.Play();
        }
    }


    private void FixedUpdate()
    {
        // Move and turn the tank.
    }


    private void Move()
    {
        // Adjust the position of the tank based on the player's input.

        float AxisValue = Input.GetAxis(m_MovementAxisName);
        if (AxisValue!=0)
        {
            Vector3 HuongDi = new Vector3(0, 0, Input.GetAxis(m_MovementAxisName) * m_Speed);
            transform.Translate(HuongDi );
            Turn();
        }
        else
        {
            m_EngineDriving.Pause();
            if (!m_Idling.isPlaying) m_Idling.Play();
        }

    }

    
    private void Turn()
    {
        // Adjust the rotation of the tank based on the player's input.
        transform.Rotate(new Vector3(0, Input.GetAxis(m_TurnAxisName)*m_TurnSpeed, 0));
    }
}