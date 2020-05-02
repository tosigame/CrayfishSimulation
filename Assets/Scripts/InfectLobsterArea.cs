using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectLobsterArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Food" && other.gameObject.tag !="InfectionArea")
        {
            other.gameObject.GetComponent<LobsterRoots>().MakeInfection();
        }
    }
}
