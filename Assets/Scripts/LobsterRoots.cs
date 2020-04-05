﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobsterRoots : MonoBehaviour
{
    public int food;
    public GameObject foodPrefab;
    public int foodValue = 1;
    private float deathChance = 0.10f;
    public int counts ;
    private bool infection;
    public float minScaleSize;
    public float xScaleIncrement;
    public Vector3 lobsterGrow; 

    public virtual void Start()
    {
        counts = 0;
       
        xScaleIncrement = 0.01f;
        lobsterGrow = new Vector3(xScaleIncrement, 0, xScaleIncrement);
        minScaleSize = 3;
        
        Invoke("CheckFood", 7f);
    }
    public void MakeInfection()
    {
        infection = true;
        CheckInfection();
    } 
    virtual public void CheckInfection()
    {
        
        if (infection == true)
        {
           
            if (Random.Range(0f, 1f) <= deathChance)
            {
                LobsterDeath();
            }
            else
            {
                deathChance = deathChance * 2;
                counts++;
                if (counts < 3)
                {
                    infection = !infection;
                    counts--;
                    deathChance = 0.1f;
                }
                
                Invoke("CheckInfection",10f);
            }

        }
    }
    public void CheckFood()
    {
        if (food <= 0)
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
                Instantiate(gameObject);
                transform.localScale = Vector3.one;
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
