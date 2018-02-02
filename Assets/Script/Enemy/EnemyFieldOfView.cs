using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFieldOfView : MonoBehaviour
{
    public float FieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 personalLastSighting;


    private NavMeshAgent nav;
    private SphereCollider col;
    private GameObject player;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        Debug.Log(playerInSight);
        
    }
   void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInSight = false;

            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if(angle < FieldOfViewAngle * 0.5f)
            {
                RaycastHit hit;

                if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
                {
                    if(hit.collider.gameObject == player)
                    {
                        playerInSight = true;
                        

                    }
                }
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            playerInSight = false;
    }


}