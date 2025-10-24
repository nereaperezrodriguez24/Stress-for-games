using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject OjoDerc;
    public GameObject OjoIzq;

    private Animator EnemyAnim;

    public Transform pointA;
    public Transform pointB;
    public Transform player;
    public Transform lana;
    private Transform target;
    
    public float stopDistance = 0.5f;
    public float detectRange = 5.0f;
    public float rotationSpeed;
    public bool IsAngry;
    
    private bool chasingPlayer = false;

    void Start()
    {
        EnemyAnim = GetComponent<Animator>();
        target = pointA;
        agent.SetDestination(target.position);//goes to point A
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if(distanceToPlayer <= detectRange)//if player is on the range
        {
            chasingPlayer = true;
            agent.SetDestination(player.position);//it chase it            
            IsAngry = true;
        }
        else
        {
            chasingPlayer = false;
            Quaternion toRotation = target.rotation; //create the rotate in direction of target
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);//rotate
            if (target.rotation == transform.rotation)
            {
                agent.SetDestination(target.position);
            }
        }

        if (chasingPlayer == false)// if not it patrol
        {
            if (Vector3.Distance(transform.position, target.position) <= stopDistance)
            {
                // change target
                if (target == pointA)
                {
                    target = pointB;
                }
                else
                {
                    target = pointA;
                }
                agent.SetDestination(target.position);
            }
        } 
    }
    public void Animation()
    {
        if (IsAngry == false)
        {
            EnemyAnim.SetBool("IsAngry", false);

        }
        else
        {
            EnemyAnim.SetBool("IsAngry", true);
        }
    }
}
