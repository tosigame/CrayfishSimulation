using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGodCommands : MonoBehaviour
{
   //  GameObject.Find("CannibalLobster").getComponent<BoardManager>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.S))
        {
            foreach (GameObject lobsterCom in GameObject.FindGameObjectsWithTag("CollectiveLobster"))
            {
                if (Random.Range(0, 1f) < 0.5)
                {
                    Destroy(lobsterCom.gameObject);
                }
            }
        }

            if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L)) {
                foreach (GameObject lobsterCom in GameObject.FindGameObjectsWithTag("Lobster"))
                {
                    if (Random.Range(0, 1f) < 0.5)
                    {
                        Destroy(lobsterCom.gameObject);
                    }
                }
            }
        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.U)) { 
            foreach (GameObject lobsterCom in GameObject.FindGameObjectsWithTag("CannibalLobster"))
            {
                if (Random.Range(0, 1f) < 0.5)
                {
                    Destroy(lobsterCom.gameObject);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.B)){
          //  Instantiate(CannibalLobster, new Vector3(Random.Range(-50f, 50f), 0.5f, Random.Range(-50f, 50f)), Quaternion.identity);
        }
       
    }
}
