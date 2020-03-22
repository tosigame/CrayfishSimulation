using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamGameController : MonoBehaviour
{
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;


        mainCamera.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {

            if (mainCamera.gameObject.activeSelf == false)
            {
                mainCamera.gameObject.SetActive(true);
            }
            else
            {
                mainCamera.gameObject.SetActive(false);
            }

        }
    }
}
