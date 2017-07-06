using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using System.Linq;

public class ListCreator : MonoBehaviour 
{
    [System.Serializable]
    public struct Content
    {
        public Transform Parent;
        public string FileName;
    }

    [SerializeField]
    private Content[] content;

    [SerializeField]
    private GameObject textPrefab;


    #region Individual Lists
    private List<string> bodyStrings = new List<string>();
    private List<string> descriptionStrings = new List<string>();
    private List<string> thingStrings = new List<string>();
    private List<string> themeStrings = new List<string>();
    private List<string> flairStrings = new List<string>();
    #endregion

    public List<string> BodyStrings { get { return bodyStrings; } }
    public List<string> DescriptionStrings { get { return descriptionStrings; } }
    public List<string> ThingStrings { get { return thingStrings; } }
    public List<string> ThemeStrings { get { return themeStrings; } }
    public List<string> FlairStrings { get { return flairStrings; } }

    public void PrintDescriptionCount()
    {
        Debug.Log("Creator::Description -- " + descriptionStrings.Count);
    }

    private void Start () 
	{
        for(int i = 0; i < content.Length; i++)
        {
            Debug.Log("Index: " + i.ToString() + " -- " + content[i].FileName.ToString());

            /*
             
             foreach (string s in strarr)
             {
                 GameObject textGO = Instantiate(textPrefab, this.transform);
                 textGO.GetComponent<Text>().text = s;
             }
             
             */

            Init(content[i], i);
        }
	}

    private void Init(Content currentContent, int contentIndex)
    {
        string listFileName = currentContent.FileName;
        string fileContents = ReadFile(listFileName);
        List<string> temp = new List<string>();

        switch (contentIndex)
        {
            case 0: // body
                temp = BreakTextByLine(fileContents);
                PopulateList(bodyStrings, temp);
                CreateListUI(bodyStrings, currentContent.Parent);
                break;

            case 1: // description
                temp = BreakTextByLine(fileContents);
                PopulateList(descriptionStrings, temp);
                CreateListUI(descriptionStrings, currentContent.Parent);
                break;

            case 2: // thing
                temp = BreakTextByLine(fileContents);
                PopulateList(thingStrings, temp);
                CreateListUI(thingStrings, currentContent.Parent);
                break;

            case 3: // theme
                temp = BreakTextByLine(fileContents);
                PopulateList(themeStrings, temp);
                CreateListUI(themeStrings, currentContent.Parent);
                break;

            case 4: // flair
                temp = BreakTextByLine(fileContents);
                PopulateList(flairStrings, temp);
                CreateListUI(flairStrings, currentContent.Parent);
                break;
        }
    }

    //private void Init()
    //{
    //    //string str = ReadFile(listFileName);
    //    string str = "";
    //    List<string> strarr = BreakTextByLine(str);


    //    foreach (string s in strarr)
    //    {
    //        GameObject textGO = Instantiate(textPrefab, this.transform);
    //        textGO.GetComponent<Text>().text = s;
    //    }

    //    if (listFileName.Contains("thing"))
    //    {
    //        PopulateList(thingStrings, strarr);
    //    }
    //    if (listFileName.Contains("flair"))
    //    {
    //        PopulateList(flairStrings, strarr);
    //    }
    //    if (listFileName.Contains("theme"))
    //    {
    //        PopulateList(themeStrings, strarr);
    //    }
    //    if (listFileName.Contains("body"))
    //    {
    //        PopulateList(bodyStrings, strarr);
    //    }
    //    if (listFileName.Contains("description"))
    //    {
    //        PopulateList(descriptionStrings, strarr);
    //        Debug.Log(descriptionStrings.Count);
    //    }
    //}

    private void CreateListUI(List<string> list, Transform parent)
    {
        foreach (string s in list)
        {
            GameObject textGO = Instantiate(textPrefab, parent);
            textGO.GetComponent<Text>().text = s;
        }
    }

    private void PopulateList(List<string> a, List<string> b)
    {
        a.AddRange(b);
    }

    private List<string> BreakTextByLine(string text)
    {
        string[] result = text.Split(',');
        return result.ToList();
    }

    private string ReadFile(string listFileName)
    {
        StringBuilder sb = new StringBuilder();
        TextAsset txt = (TextAsset)Resources.Load(listFileName, typeof(TextAsset));

        sb.Append(txt.text);

        return sb.ToString();
    }
}
