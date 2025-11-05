using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject OjosChill;
    public GameObject OjosMal;
    public GameObject DeathPanel;

    public PlayerManager PlayerManager;
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
        DeathPanel.SetActive(false);
        OjosMal.gameObject.SetActive(false);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if(distanceToPlayer <= detectRange)//if player is on the range
        {
            chasingPlayer = true;
            agent.SetDestination(player.position);//it chase it            
            IsAngry = true;
            OjosChill.gameObject.SetActive(false);
            OjosMal.gameObject.SetActive(true);

        }
        else
        {
            OjosMal.gameObject.SetActive(false);
            OjosChill.gameObject.SetActive(true);
            chasingPlayer = false;
            agent.SetDestination(target.position);
            transform.rotation = target.transform.rotation;
            
        }

        if (chasingPlayer == false)// if not, it patrol
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
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Player"))
        {
            DeathPanel.SetActive(true);
            Debug.Log("Muerto");
            PlayerManager.IsAlive = false;
        }
    }
}
