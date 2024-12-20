using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    PlayerHealth playerHealth;

    public float amount;
    //public float damageTime;
    float currentDameTime;

    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerHealth.life > 0)
        {
            currentDameTime += Time.deltaTime;
            if (currentDameTime >= 0)
            {
                playerHealth.life -= amount;
                currentDameTime = 0.0f;
                Debug.Log("Daño aplicado: " + amount + " - Vida restante: " + playerHealth.life);
            }
        }
       

    }
}
