﻿using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public float m_StartingHealth = 100f;
    public Slider m_Slider;
    public Image m_FillImage;
    public Color m_FullHealthColor = Color.green;  
    public Color m_ZeroHealthColor = Color.red;
    public GameObject m_ExplosionPrefab;


    private AudioSource m_ExplosionAudio;          
    private ParticleSystem m_ExplosionParticles;   


    public float m_CurrentHealth;
    public bool m_Dead;


    /// //////////////////////////////////////////////////////////////////////////
    private void Awake()
    {
        //m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        //m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        //m_ExplosionParticles.gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;

        SetHealthUI();
    }
    /// //////////////////////////////////////////////////////////////////////////

    public void TakeDamage(float amount)
    {
        // Adjust the tank's current health, update the UI based on the new health and check whether or not the tank is dead.
        m_CurrentHealth = m_CurrentHealth - amount * 10;
        gameObject.GetComponentInChildren<CapsuleCollider>().gameObject.transform.localScale = new Vector3(0.1f,1-((100-m_CurrentHealth)/100f),0.1f);
        if (m_CurrentHealth <= 0)
        {
            m_Dead = true;
            OnDeath();
        }
    }


    private void SetHealthUI()
    {
        // Adjust the value and colour of the slider.
    }


    private void OnDeath()
    {
        // Play the effects for the death of the tank and deactivate it.
        Transform temp = gameObject.GetComponent<Transform>();
        GameObject Effect = Instantiate(m_ExplosionPrefab, temp.position, temp.rotation);
        Effect.gameObject.GetComponent<ParticleSystem>().Play();
        //Destroy(gameObject, 0.5f);
        //Destroy(gameObject);
        gameObject.active = false;
    }
}