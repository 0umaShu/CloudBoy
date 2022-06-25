using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    private float startingHealth;
    public float currentHealth { get; private set; }

    [Header("Components")]
    [SerializeField]
    private Behaviour[] components;

    private playerRespawn pRespawn;

    void Awake()
    {
        currentHealth = startingHealth;
        pRespawn = GetComponent<playerRespawn>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        //player dies
        if (currentHealth == 0)
        {
            //Deactivate all attached component classes
            foreach (Behaviour component in components)
                component.enabled = false;
            pRespawn.Respawn();

        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respawn()
    {
        AddHealth(startingHealth);

        //Activate all attached component classes
        foreach (Behaviour component in components)
            component.enabled = true;
    }
}
