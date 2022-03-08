using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    PlayerHealth target;
    [SerializeField] float damage = 40f;
    

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        
    }


    public void attackHitEvent()
    {
        if (target == null) return;
        Debug.Log("bang bang");
        target.TakeDamagePlayer(damage);

   
         //StartCoroutine(ZombieAttackSFX());

    }
    /*IEnumerator ZombieAttackSFX()
    {
        yield return new WaitForSeconds(Random.Range(.5f, 1f));
        FindObjectOfType<AudioManager>().Play("ZombieAttack");
        
        
    }*/



}
