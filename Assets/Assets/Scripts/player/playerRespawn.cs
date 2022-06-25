using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRespawn : MonoBehaviour
{
    private Transform spawnPoint;
    private playerHealth pHealth;

    [SerializeField] private FloatSO deathCountSO;

    private void Awake()
    {
        pHealth = GetComponent<playerHealth>();
    }
    public void Respawn()
    {
        pHealth.Respawn(); //Restore player health and reset animation
        transform.position = spawnPoint.position; //Move player to checkpoint location
        deathCountSO.Value += 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "spawnPoint")
        {
            spawnPoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }
}
