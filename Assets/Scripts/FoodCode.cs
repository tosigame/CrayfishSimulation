using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCode : MonoBehaviour
{
    public bool infectedState = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag!="Food")
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
        //visual settings
        transform.GetChild(0).gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
