using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpansionMapManager : Singleton<ExpansionMapManager>
{
    [SerializeField] private GameObject missionPrefab;
    [SerializeField] private TextMesh difficultyText;
    [SerializeField] private TextMesh rewardText;

    void Start()
    {
        StartLevel();    //Must change this back when more is done on the expansionmap
    }

    public void LoadMissionPrefab(Vector3 nodePos, Node.MissionDetails missionData)
    {
        missionPrefab.SetActive(true);
        missionPrefab.transform.position = nodePos;
        difficultyText.text = missionData.diff.ToString();
        rewardText.text = missionData.reward.ToString();
        LoadLevelDetails(missionData);
    }

    public void LoadLevelDetails(Node.MissionDetails details)
    {
        WaveManager.Instance.Waves = details.Waves;
    }

    public void StartLevel()
    {
        //load in string levelname here some way  
        UIManager.Instance.ToogleGameUI();
        GameManager.Instance.LoadLevel("TheShore");
        GameManager.Instance.Unloadlevel("ExpansionMap");

    }
}
