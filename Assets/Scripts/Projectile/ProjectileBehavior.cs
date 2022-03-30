using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    private int damage;
    public int Damage { get => damage; set => damage = value; }

    private float speed = 1;
    public float Speed { get => speed; set => speed = value; }

    void Start()
    {
        Invoke("DestroyProjectile", 3);
    }
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, Speed);
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != gameObject.layer)
        {
            other.gameObject.GetComponent<EnemyHP>().Hit(damage);
            DestroyProjectile();
        }
    }
}
