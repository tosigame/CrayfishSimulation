/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;


public class Window_Graph : MonoBehaviour {

    //List<int> valueList = new List<int>();
    List<Color> colors = new List<Color>();
    //List<int> valueList2 = new List<int>();
    List<String> tags = new List<String>();
    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;
    public int currentMax=0;
    List<List<int>> listOfList = new List<List<int>> { };

    public void CreateGraph(String tagName,Color dotColor)
    {
        listOfList.Add(new List<int>());
        colors.Add(dotColor);
        tags.Add(tagName);
        
    }
    private void UpdateGraph()
    {
        
        for (int i = 0; i < tags.Count; i++)
        {

            listOfList[i].Add(GameObject.FindGameObjectsWithTag(tags[i]).Length);
            if (listOfList[i].Count > 30)
            {
                listOfList[i].RemoveAt(0);
                
            }
        }
       
        
        
        SearchForMax();
        ClearGraph();
        ShowGraph();
       



        Invoke("UpdateGraph", 1f);
    }
    private void Awake() {
        //listOfList.Add(valueList);
        //listOfList.Add(valueList2);
        CreateGraph("CollectiveLobster", new Color(54/255f, 249/255f, 1f, 1f));
        CreateGraph("CannibalLobster", new Color(243 / 255f , 6/255f , 151/255f,1f));
        CreateGraph("Lobster", new Color( 1f,  18 / 255f,  18 / 255f, 1f));
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();

       
        Invoke("UpdateGraph", 1f);
        //ShowGraph(valueList);

    }

    private GameObject CreateCircle(Vector2 anchoredPosition, Color color) {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        gameObject.GetComponent<Image>().color = color;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(1, 1);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }
    private void SearchForMax()
    {
        int tmpMax = 0;
        foreach (List<int> elem in listOfList)
        {


            for (int i = 0; i < elem.Count; i++)
            {
                if (tmpMax <= elem[i])
                {
                    tmpMax = elem[i];
                }

            }
        }
          currentMax = tmpMax;


    }
    private void ClearGraph()
    {
        foreach (Transform child in graphContainer.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    private void ShowGraph() {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = currentMax;
        float xSize = 15f;


     

        
        for (int f = 0; f < tags.Count; f++)
        {
            GameObject lastCircleGameObject = null;

            for (int i = 0; i < listOfList[f].Count; i++)
            {
                float xPosition = xSize + i * xSize;
                float yPosition = (listOfList[f][i] / yMaximum) * graphHeight;
                GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition), colors[f]);
                if (lastCircleGameObject != null)
                {
                    CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition,colors[f]);
                }
                lastCircleGameObject = circleGameObject;
            }
        }
    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB, Color color) {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = color;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
    }
  
}
