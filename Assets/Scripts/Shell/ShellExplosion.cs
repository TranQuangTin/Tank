using System.Collections;
using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;
    public GameObject m_ExplosionParticles;       
    public AudioSource m_ExplosionAudio;              
    public float m_MaxDamage = 100f;                  
    public float m_ExplosionForce = 1000f;            
    public float m_MaxLifeTime = 200f;                  
    public float m_ExplosionRadius = 5f;
    public Collider ParentColider;
    private void Start()
    {
        
        Destroy(gameObject, m_MaxLifeTime);
    }
    public void Update()
    {
        Move();
    }
    public void Move()
    {
        transform.Translate(0, 0,  0.4f);
    }
    public void OnTriggerEnter(Collider other)
    {
        // Find all the tanks in an area around the shell and damage them.

        Vector3 ShellLocation = transform.position;
        m_ExplosionAudio.Play();
        if (other != ParentColider)
        {
            GameControl GameCT = GameObject.Find("Game Control").GetComponent<GameControl>();
            Transform[] Temp = GameCT.ListTankTransform;
            for (int i = 0; i < Temp.Length; i++)
            {
                if (Temp[i].gameObject.GetComponent<Collider>() != ParentColider)
                {
                    float Distance = Vector3.Distance(Temp[i].transform.position, ShellLocation);
                    if (Distance < 5)
                    {
                        Temp[i].GetComponent<TankHealth>().TakeDamage(Distance);
                    }
                }
            }

            GameObject exploder = Instantiate(m_ExplosionParticles, ShellLocation, transform.rotation);
            exploder.gameObject.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
            Destroy(exploder, 1);
        }
    }


    private float CalculateDamage(Vector3 targetPosition)
    {
        // Calculate the amount of damage a target should take based on it's position.
        return 0f;
    }
}