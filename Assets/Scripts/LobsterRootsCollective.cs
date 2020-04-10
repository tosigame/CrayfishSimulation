using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobsterRootsCollective : LobsterRoots
{


    public override void LobsterBirth()
    {
        if (food >= 5 && transform.localScale.x >= 1.7)
        {
            CheckFood();
            food = 0;
            int quant = Random.Range(1, 2);
            for (int i = 0; i < quant; i++)
            {
                GameObject newLobster = Instantiate(gameObject);
                newLobster.transform.localScale = Vector3.one;
            }
        }

    }

}
