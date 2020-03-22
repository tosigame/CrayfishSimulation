using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannibalLobsterMech : MonoBehaviour
{
    public float maxScaleSize;
    // Start is called before the first frame update
    void Start()
    {
        maxScaleSize = 4.93f;
    }
    public void EatOther(float FValue)
    {
        GetComponent<LobsterRoots>().food += (int)(FValue - 0.95) * 5;
        if (transform.localScale.x < maxScaleSize)
        {
            transform.localScale += new Vector3((FValue - 0.95f) / 5, 0, (FValue - 0.95f) / 5);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CannibalLobster")
        {
            if (transform.localScale.x - other.gameObject.transform.localScale.x > 0.6 && other.gameObject.transform.localScale.x > 1.5)
            {
                EatOther(other.gameObject.transform.localScale.x);

                Destroy(other.gameObject);
            }
           
        }

        else if (other.gameObject.tag != "Food")
        {

            if (transform.localScale.x - other.gameObject.transform.localScale.x > 0.2)
            {
                EatOther(other.gameObject.transform.localScale.x);

                Destroy(other.gameObject);
            }
        }
    } 
    

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
