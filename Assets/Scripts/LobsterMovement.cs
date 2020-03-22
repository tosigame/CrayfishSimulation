using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobsterMovement : MonoBehaviour
{
    public GameObject lobsterPrefab;
    public Vector3 movementDirection;
   
    void MoveDecision()
    {
        movementDirection.x = Random.Range(-0.5f, 0.5f);
        movementDirection.z = Random.Range(-0.5f, 0.5f);
    }
    void Update()
    {
        if (Random.Range(0, 1f)<0.01){
            MoveDecision();
        }
        transform.Translate(movementDirection * Time.deltaTime * 15f);
    }
}
