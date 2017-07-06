using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCreator : MonoBehaviour
{
    public ListCreator Lists;

    [SerializeField]
    private Text genBodyLabel;
    [SerializeField]
    private Text genDescLabel;
    [SerializeField]
    private Text genThingLabel;
    [SerializeField]
    private Text genFlairLabel;
    [SerializeField]
    private Text genThemeLabel;

    private void Start()
    {
        if (!Lists)
        {
            Lists = FindObjectOfType<ListCreator>();
            if (!Lists)
            {
                Debug.LogError("ListCreator could not be found!");
            }
        }        
    }

    public void GenerateMonster()
    {
        genBodyLabel.text = Lists.BodyStrings[Random.Range(0, Lists.BodyStrings.Count - 1)];
        genDescLabel.text = Lists.DescriptionStrings[Random.Range(0, Lists.DescriptionStrings.Count - 1)];
        genThingLabel.text = Lists.ThingStrings[Random.Range(0, Lists.ThingStrings.Count - 1)];
        genFlairLabel.text = Lists.FlairStrings[Random.Range(0, Lists.FlairStrings.Count - 1)];
        genThemeLabel.text = Lists.ThemeStrings[Random.Range(0, Lists.ThemeStrings.Count - 1)];
    }

    public void Exit()
    {
        Application.Quit();
    }
}
