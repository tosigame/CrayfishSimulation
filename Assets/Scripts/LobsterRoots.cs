using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobsterRoots : MonoBehaviour
{
    public int food;
    public GameObject foodPrefab;
    public GameObject TestInfection;
    
    
    public int foodValue = 1;
    protected float deathChance = 0.80f;
    public int counts ;
    private bool infection;
    public float minScaleSize;
    public float xScaleIncrement;
    public Vector3 lobsterGrow;
    private Vector3 infectionSize;

    public virtual void Start()
    {
        counts = 0;
       
        xScaleIncrement = 0.01f;
        lobsterGrow = new Vector3(xScaleIncrement, 0, xScaleIncrement);
        infectionSize = new Vector3(1, 0.3f, 1);
        
        minScaleSize = 3;
        
        Invoke("CheckFood", 7f);
    }
    public void MakeInfection()
    {

        if (infection == true)
        {
            Debug.Log("Already working");
            return;
        }
        else
        {
            foreach ( Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            if (transform.childCount > 0)
            {
                Debug.Log("Ayiayai We have childs");

            }
            infection = true;
            
            GameObject infectionSympton = Instantiate(TestInfection, transform.position, Quaternion.identity);
            infectionSympton.transform.SetParent(transform);
            infectionSympton.transform.localScale = infectionSize;
           
            Debug.Log("Lobster infected");
            CheckInfection();
        }
    } 
    public void CheckInfection()
    {
        
        if (infection == true)
        {
            Debug.Log("Positive to infection");
            if (Random.Range(0f, 1f) <= deathChance)
            {
                LobsterDeath();
            }
            else
            {
                
                counts++;
                if (counts > 3)
                {
                    infection = false;
                    counts = 0;
                    Destroy(transform.GetChild(0).gameObject);
                }
                else
                {

                    Invoke("CheckInfection", 10f);
                }
            }

        }
    }
    public void CheckFood()
    {
        if (food <= 1)
        {
            LobsterDeath();
        }
        else
        {
            food = 0;
            Invoke("CheckFood", 7f);
        }

    }

    public void LobsterDeath()
    {
        
            if (infection == true)
            {
            Debug.Log("infected Death");
            GameObject.Find("Board 1").GetComponent<BoardManager>().SpawnInfectedFood(transform.position);
                
            }
            Destroy(gameObject);
        

       
    }

   virtual public void LobsterBirth()
    {
        if (food >= 5 && transform.localScale.x >= 2)
        {
            CheckFood();
            food = 0;
            for (int i = 0; i < 1; i++)
            {
                GameObject newLobster = Instantiate(gameObject);
                newLobster.transform.localScale = Vector3.one;
            }
           
        }
    }

    virtual public void Eat()
    {
        food += foodValue;
        if (transform.localScale.x < minScaleSize)
        {
            transform.localScale += lobsterGrow;
        }
        
    }
  
    void Update()
    {
        LobsterBirth();
    }
}
