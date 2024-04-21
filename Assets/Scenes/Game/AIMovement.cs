using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour

{
    public SpawnPlayer spawnPlayer;
    public Transform playerTransform;
    NavMeshAgent agent;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform) {
            agent.destination = playerTransform.position;
            animator.SetFloat("speed", agent.velocity.magnitude);
        }
        else
        {
            enabled = false;
        }
    }
    private void OnTriggerEnter(Collider  collider)
    {

        if (collider.gameObject.TryGetComponent(out PlayerMovement _))
        {
            spawnPlayer.GameOver();
        }
    }
}
