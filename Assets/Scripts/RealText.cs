using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class RealText : MonoBehaviour
{
    public static int fileNumber;
    private string fileName = "results";
    private string fullFileName;
    private int timeLimit=390;
    private int currentTime;
    static int lobsterSurvivalCount=-1;
    static int collectiveLobsterSurvivalCount=-1;
    static int cannibalLobsterSurvivalCount=-1;
    int CountLobsters;
    int collectiveLobsterCount;
    int cannibalLobsterCount;
    public void CreateText()
    {
        File.WriteAllText(fullFileName, contents: "Cannibal,collective,NormalLobsters,CannibalCount,CollectiveCount,NormalLobstersCount \n");
    }
    public void NewFile()
    {
        if (cannibalLobsterCount > 0)
        {
            cannibalLobsterSurvivalCount++;
        }
        if (collectiveLobsterCount > 0)
        {
            collectiveLobsterSurvivalCount++;
        }
        if (CountLobsters > 0)
        {
            lobsterSurvivalCount++;
        }
        File.AppendAllText(Application.dataPath + "/ResultsLog/StatisticResults.csv", 
            contents: cannibalLobsterCount.ToString() + ","
            + collectiveLobsterCount.ToString() + ","
            + CountLobsters.ToString() + ","
            + cannibalLobsterSurvivalCount.ToString() + ","
            + collectiveLobsterSurvivalCount.ToString() + ","
            + lobsterSurvivalCount.ToString() + "\n");
        currentTime = 0;
        fileNumber++;
        GameObject.Find("TextCurrentSimulation").GetComponent<Text>().text = "Simulation Count: " + fileNumber;
        fullFileName = Application.dataPath + "/ResultsLog/" + fileName + "-" + fileNumber + ".csv";
    }
    public void TextAdding()
    {
        if (
            timeLimit < currentTime 
            || cannibalLobsterCount == 0 
            || (collectiveLobsterCount == 0 && CountLobsters == 0 )
           )
        {

            NewFile();
            GetComponent<BoardManager>().RestartSimulation();
        }
         cannibalLobsterCount = GameObject.FindGameObjectsWithTag("CannibalLobster").Length;
         collectiveLobsterCount = GameObject.FindGameObjectsWithTag("CollectiveLobster").Length;
         CountLobsters = GameObject.FindGameObjectsWithTag("Lobster").Length;
        File.AppendAllText(fullFileName, contents: cannibalLobsterCount.ToString() + "," + collectiveLobsterCount.ToString() + "," + CountLobsters.ToString() + "\n");
        currentTime++;
        Invoke("TextAdding", 1f);
        
        
    }
   public void Begin()
    {
        File.WriteAllText(Application.dataPath + "/ResultsLog/StatisticResults.csv", contents: "Cannibal,collective,NormalLobsters,CannibalCount,CollectiveCount,NormalLobstersCount \n");
        fileNumber = 0;
        NewFile(); 
        CreateText();
        TextAdding();
    }
}
