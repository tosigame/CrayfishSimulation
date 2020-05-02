using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCode : MonoBehaviour
{
    public bool infectedState = false;
    public GameObject TestInfection;
  
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag!="Food" && other.gameObject.tag != "InfectionArea")
        {
            Destroy(gameObject);
            if (infectedState)
            {
               
                other.gameObject.GetComponent<LobsterRoots>().MakeInfection();
            }
            other.gameObject.GetComponent<LobsterRoots>().Eat();
        }
      
    }
    public void MakeInfection()
    {
     
        transform.GetChild(0).gameObject.SetActive(true);
        infectedState = true;
        GameObject infectionSympton = Instantiate(TestInfection, transform.position, Quaternion.identity);
        infectionSympton.transform.SetParent(transform);
        
       

    }
   
}
