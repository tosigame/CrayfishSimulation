using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class BoardManager : MonoBehaviour
{
    [HideInInspector] public GameObject settingPanel;
    public GameObject lobsterPrefab;
    public GameObject foodPrefab;
    public GameObject CollectiveLobster;
    public GameObject CannibalLobster;
    public float lobsterAdultChance;
    public float cannibalLobsterAdultChance;
    public float collectiveLobsterAdultChance;
    public int collectiveSpawnAmount;
    public int cannibalSpawnAmount;
    public int lobsterSpawnAmount;
    public int foodSpawnAmount;
    public int foodSpawnRate;
    public static bool isPaused;
    public float boardScale;
    

    public void ButtonStart()
    {
        settingPanel = GameObject.Find("SettingPanel");
        settingPanel.gameObject.SetActive(false);
        RestartSimulation();
        Time.timeScale = 1;
        isPaused = false;
        GetComponent<RealText>().Begin();
    }
    public void CannibalLobsterChange()
    {
        cannibalSpawnAmount =int.Parse(GameObject.Find("CannibalLobsterInput").GetComponent<InputField>().text);
    }
    public void CollectiveLobsterChange()
    {
        collectiveSpawnAmount = int.Parse(GameObject.Find("CollectiveLobsterInput").GetComponent<InputField>().text);
    }
    public void LobsterChange()
    {
        lobsterSpawnAmount = int.Parse(GameObject.Find("LobsterInput").GetComponent<InputField>().text);
    }
    public void BasicFoodSpawnChange()
    {
        foodSpawnAmount = int.Parse(GameObject.Find("BasicFoodAmountInput").GetComponent<InputField>().text);
    }
    public void FoodSpawnRateChange()
    {
        foodSpawnRate = int.Parse(GameObject.Find("FoodSpawnRateInput").GetComponent<InputField>().text);
    }
    public void RestartSimulation()
    {
        
        foreach (GameObject lobsterCom in GameObject.FindGameObjectsWithTag("CollectiveLobster"))
        {         
                Destroy(lobsterCom.gameObject);          
        }
        foreach (GameObject lobsterCom in GameObject.FindGameObjectsWithTag("Lobster"))
        {
            Destroy(lobsterCom.gameObject);
        }
        foreach (GameObject lobsterCom in GameObject.FindGameObjectsWithTag("CannibalLobster"))
        {
            Destroy(lobsterCom.gameObject);
        }
        foreach (GameObject lobsterCom in GameObject.FindGameObjectsWithTag("Food"))
        {
            Destroy(lobsterCom.gameObject);
        }
        LobsterBasicSpawn();

    }
    public Vector3 BoardScaleVector()
    {
        return new Vector3(Random.Range(-boardScale, boardScale), 0.5f, Random.Range(-boardScale, boardScale));

    }
    void Start()
    {
        isPaused = true;
        Time.timeScale = 0;      
    }
    void LobsterBasicSpawn()
    {
        for (int i = 0; i < lobsterSpawnAmount; i++)
        {
            GameObject lobster = Instantiate(lobsterPrefab, BoardScaleVector(), Quaternion.identity);
            if (Random.value > lobsterAdultChance)
            {
                lobster.transform.localScale += new Vector3(2.5f, 0f, 2.5f);
            }

        }
        for (int i = 0; i < collectiveSpawnAmount; i++)
        {
            GameObject lobster = Instantiate(CollectiveLobster, BoardScaleVector(), Quaternion.identity);
            if (Random.value > cannibalLobsterAdultChance)
            {
                lobster.transform.localScale += new Vector3(2.5f, 0f, 2.5f);
            }
        }
        for (int i = 0; i < cannibalSpawnAmount; i++)
        {
            GameObject lobster = Instantiate(CannibalLobster, BoardScaleVector(), Quaternion.identity);
            if (Random.value > collectiveLobsterAdultChance)
            {
                lobster.transform.localScale += new Vector3(2.5f, 0f, 2.5f);
            }
        }
        for (int i = 0; i < foodSpawnAmount; i++)
        {
            Instantiate(foodPrefab, BoardScaleVector(), Quaternion.identity);
        }
    }
    void FoodSpawn()
    {
        for (int i = 0; i < foodSpawnRate; i++)
        {
            Instantiate(foodPrefab, BoardScaleVector(), Quaternion.identity);
        }
    }

    private void OnGUI()
    {
         int CountLobsters= GameObject.FindGameObjectsWithTag("Lobster").Length;
        GameObject.Find("TextLobsterCount").GetComponent<Text>().text= "Crayfish Count: " + CountLobsters;
        GameObject.Find("TextCollectiveLobsterCount").GetComponent<Text>().text = "Collective Crayfish Count: " + GameObject.FindGameObjectsWithTag("CollectiveLobster").Length.ToString();
        GameObject.Find("TextCannibalLobsterCount").GetComponent<Text>().text = "Cannibal Crayfish Count: " + GameObject.FindGameObjectsWithTag("CannibalLobster").Length.ToString();
       

    }
    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            FoodSpawn();
        }
    }
}