using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : StateMachineBehaviour
{
    float timer;
    public int x;
    List<Transform> points = new List<Transform>();
    NavMeshAgent agent;
    Transform player;
    float chaseRange = 7;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;
        foreach (Transform t in pointsObject)
        {
            points.Add(t);
        }
        agent=animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(points[Random.Range(0, points.Count)].position);

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

  
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(points[Random.Range(0,points.Count)].position);
        }
        timer += Time.deltaTime;
        if (timer > x)
        {
            animator.SetBool("IsPatrolling", false);
            x = Random.Range(5, 45);
        }
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < chaseRange)
        {
            animator.SetBool("IsChasing", true);
        }
    }

  
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       agent.SetDestination(agent.transform.position);
    }

  
}
