using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : HP
{
    public override void Hit(int damage)
    {
        base.Hit(damage);

        if(hP <= 0)
        {
            gameObject.GetComponent<ItemsDrop>().Drop();
            Death();
        }
    }
}
