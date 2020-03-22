using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobsterRootsCannibal : LobsterRoots
{
 

    public override void LobsterBirth()
    {
        if (food >= 10 && transform.localScale.x >= 2.5)
        {
            LobsterDeath();
            food = 0;
            int quant = Random.Range(1, 4);
            for (int i = 0; i < quant; i++)
            {
                Instantiate(gameObject);
                transform.localScale = Vector3.one;
            }
        }
    }
    override public void Eat()
    {
        food += foodValue;
        if (transform.localScale.x < minScaleSize)
        {
            transform.localScale += lobsterGrow*2;
        }

    }
}
