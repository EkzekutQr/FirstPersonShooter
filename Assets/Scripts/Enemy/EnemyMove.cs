using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] float speed = 1;

    [SerializeField] float stopMoveDistance = 1.5f;

    Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        if(player == null)
        {
            player = GameObject.Find("Player");
        }
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void FixedUpdate()
    {
        MovementLogic();
    }
    void MovementLogic()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if(distance > stopMoveDistance)
        {
            Vector3 moveDirection;

            gameObject.transform.LookAt(new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z));

            moveDirection = player.transform.position - gameObject.transform.position;

            moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);

            rb.AddForce((moveDirection.normalized * speed), ForceMode.Force);

            rb.velocity = rb.velocity - new Vector3(rb.velocity.x * 0.1f, 0, rb.velocity.z * 0.1f);
        }
    }
}
