using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLayoutToJSON : MonoBehaviour
{
    public GameObject leftScreen;
    public GameObject rightScreen;

    // Start is called before the first frame update
    void Start()
    {
        LoadJson();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveJson()
    {
        IUILayoutSerializable[] allPanels = transform.GetComponentsInChildren<IUILayoutSerializable>();
        PanelFolderJsonData jsonData = new PanelFolderJsonData();
        jsonData.panels = new List<PanelJsonData>();
        foreach(IUILayoutSerializable panel in allPanels)
        {
            PanelJsonData panelJson = new PanelJsonData();
            Rect tmpRect = panel.GetLayoutRect();
            panelJson.posx = tmpRect.x;
            panelJson.posy = tmpRect.y;
            panelJson.width = tmpRect.width;
            panelJson.height = tmpRect.height;
            panelJson.name = panel.GetName();
            panelJson.prefab = panel.GetPrefabKey();
            panelJson.detailLeftPrefab = panel.GetDetailLeftPrefabKey();
            panelJson.detailRightPrefab = panel.GetDetailRightPrefabKey();
            Dictionary<string, string> rawData = new Dictionary<string, string>();
            rawData["extra"] = "testExtra";
            panelJson.data = new Serialization<string, string>(rawData);
            jsonData.panels.Add(panelJson);
        }

        //如果本地没有对应的json 文件，重新创建
        if (!File.Exists(JsonPath()))
        {
            File.Create(JsonPath());
        }
        string json = JsonUtility.ToJson(jsonData, true);
        File.WriteAllText(JsonPath(), json);
        Debug.Log("保存成功");
    }

    public void LoadJson()
    {
        string json = File.ReadAllText(JsonPath());

        PanelFolderJsonData jsonData = JsonUtility.FromJson<PanelFolderJsonData>(json);
        foreach(var panel in jsonData.panels)
        {
            GameObject panelObj = Instantiate((GameObject)Resources.Load(panel.prefab));
            AbstractEventPanel eventPanel = panelObj.GetComponent<AbstractEventPanel>();
            RectTransform rectTransform = panelObj.GetComponent<RectTransform>();
            rectTransform.parent = transform;
            rectTransform.localPosition = new Vector2(panel.posx + 100, panel.posy);
            rectTransform.sizeDelta = new Vector2(panel.width, panel.height);
            rectTransform.localScale = new Vector2(1.0f, 1.0f);
            IAdditionalDataProcessor additionalDataProcessor = panelObj.GetComponent<IAdditionalDataProcessor>();
            additionalDataProcessor.ProcessAdditionalData(panel.data.ToDictionary());

            GameObject detailLeftScreen = Instantiate((GameObject)Resources.Load(panel.detailLeftPrefab), leftScreen.transform);
            RectTransform detailLeftScreenTransform = detailLeftScreen.GetComponent<RectTransform>();
            //detailLeftScreenTransform.parent = leftScreen.transform;
            detailLeftScreen.SetActive(false);

            eventPanel.detailLeftScreen = detailLeftScreen;
        }
    }

    private string JsonPath()
    {
        return "../json/test.json";
    }
}


[Serializable]
public class PanelFolderJsonData
{
    public List<PanelJsonData> panels;
}


[Serializable]
public class PanelJsonData
{
    public float posx;
    public float posy;
    public float width;
    public float height;
    public string name;
    public string prefab;
    public string detailLeftPrefab;
    public string detailRightPrefab;
    public Serialization<string, string> data;
}
