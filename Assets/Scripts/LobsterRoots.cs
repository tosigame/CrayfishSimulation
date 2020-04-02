using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobsterRoots : MonoBehaviour
{
    public int food;
    public GameObject foodPrefab;
    public int foodValue = 1;
    public float deathChance = 0.30f;
    public int counts ;
    public bool infection;
    public float minScaleSize;
    public float xScaleIncrement;
    public Vector3 lobsterGrow; 

    public virtual void Start()
    {
        counts = 0;
        IfInfectedLobster();
        xScaleIncrement = 0.01f;
        lobsterGrow = new Vector3(xScaleIncrement, 0, xScaleIncrement);
        minScaleSize = 3;
        
        Invoke("LobsterDeath", 7f);
    }
    
    virtual public void IfInfectedLobster()
    {
        
        if (infection == true)
        {
           
            if (Random.Range(0f, 1f) <= deathChance)
            {
                
               GameObject.Find("Board 1").GetComponent<BoardManager>().SpawnInfectedFood(transform.position);

                //create infected food
                Destroy(gameObject);
            }
            else
            {
                //deathChance = deathChance / 2;
                counts++;
                if (counts < 3)
                {
                    infection = !infection;
                }
                
                Invoke("IfInfectedLobster",10f);
            }

        }
    }

    public void LobsterDeath()
    {
        if (food <= 0)
        {
            if (infection == true)
            {
                GameObject.Find("Board 1").GetComponent<BoardManager>().SpawnInfectedFood(transform.position);
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }

        else
        {
            food = 0;
            Invoke("LobsterDeath", 7f);
        }
    }

   virtual public void LobsterBirth()
    {
        if (food >= 5 && transform.localScale.x >= 2)
        {
            LobsterDeath();
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
