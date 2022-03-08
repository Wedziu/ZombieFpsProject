using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    
    public void TakeDamage(float Damage)
    {
        BroadcastMessage("GetShot");
        hitPoints -= Damage;
        if(hitPoints<=0)
        {
            GetComponent<Animator>().SetTrigger("Die");
            GetComponent<EnemyAI>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject, 1f);
        }
    }
}
