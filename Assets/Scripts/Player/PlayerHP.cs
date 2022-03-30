using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : HP
{
    [SerializeField] HPCounter hPCounter;

    private void Start()
    {
        hPCounter.UpdateHPCounter(hP);
    }
    public override void Hit(int damage)
    {
        base.Hit(damage);

        hPCounter.UpdateHPCounter(hP);

        if (hP <= 0)
        {
            Death();
        }
    }
}
