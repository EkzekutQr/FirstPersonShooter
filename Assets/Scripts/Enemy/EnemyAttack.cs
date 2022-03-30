using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damage = 1;

    [SerializeField] float hitSpeed = 1;

    GameObject player;

    [SerializeField]
    float distance;

    bool isRoutineBegin = false;
    private void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }
    private void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= 1.5)
        {
            if (!isRoutineBegin)
            {
                isRoutineBegin = true;
                StartCoroutine(HitCoroutine());
            }
        }
    }
    public IEnumerator HitCoroutine()
    {
        player.GetComponent<PlayerHP>().Hit(damage);
        yield return new WaitForSeconds(hitSpeed);
        isRoutineBegin = false;
    }
}
