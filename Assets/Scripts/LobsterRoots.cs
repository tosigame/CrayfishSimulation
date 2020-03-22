using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobsterRoots : MonoBehaviour
{
    public int food;
    public int foodValue = 1;
    public float minScaleSize;
    public float xScaleIncrement;
    public Vector3 lobsterGrow; 

    void Start()
    {
        xScaleIncrement = 0.01f;
        lobsterGrow = new Vector3(xScaleIncrement, 0, xScaleIncrement);
        minScaleSize = 3;
        
        Invoke("LobsterDeath", 7f);
    }   

    public void LobsterDeath()
    {
        if (food <= 0)
            Destroy(gameObject);
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
