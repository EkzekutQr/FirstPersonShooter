using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] protected int hP = 100;

    public virtual void Hit(int damage)
    {
        hP = hP - damage;
    }
    protected void Death()
    {
        Destroy(gameObject);
    }
}
