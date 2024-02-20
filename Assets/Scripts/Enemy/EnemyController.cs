using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
       agent.SetDestination(GameManager.Instance.GetPlayerLocation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
