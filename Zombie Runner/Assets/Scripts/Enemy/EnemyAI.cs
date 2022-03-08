using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{


    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    bool zombiesfxEnabled;
    float distanceToTarget = Mathf.Infinity;
    public bool isProvoked = false;
    NavMeshAgent navMeshAgent;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<PlayerHealth>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();

        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
        if (!zombiesfxEnabled)
        {
            StartCoroutine(ZombieAttackSFX());
        }


    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();

        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }

    }
    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);

    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        Debug.Log("I attacked Target!");
    }

    public void GetShot()
    {
        isProvoked = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
    IEnumerator ZombieAttackSFX()
    {
        while (isProvoked)
        {

            zombiesfxEnabled = true;
            yield return new WaitForSeconds(Random.Range(.5f, 2f));

            FindObjectOfType<AudioManager>().Play("ZombieAttack", true);
            yield return new WaitForSeconds(Random.Range(.3f, 1.5f));
            zombiesfxEnabled = false;






        }
    }
}


