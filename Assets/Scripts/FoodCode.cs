﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag!="Food")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<LobsterRoots>().Eat();
        }
      
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
