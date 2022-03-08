using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    DeathHandler deathHandler;
    private void Start()
    {
        deathHandler = GetComponent<DeathHandler>();
    }


    public void TakeDamagePlayer(float damage)
    {
        health -= damage;
        GetComponent<DisplayDamage>().ShowDamageCanvas();
        if(health<=0f)
        {
            deathHandler.handleDeath();
        }
    }
}
