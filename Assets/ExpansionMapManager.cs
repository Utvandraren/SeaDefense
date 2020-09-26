using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpansionMapManager : Singleton<ExpansionMapManager>
{
    [SerializeField] private GameObject missionPrefab;
    [SerializeField] private TextMesh difficultyText;
    [SerializeField] private TextMesh rewardText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMissionPrefab(Vector3 nodePos, Node.MissionDetails missionData)
    {
        missionPrefab.SetActive(true);
        missionPrefab.transform.position = nodePos;
        difficultyText.text = missionData.diff.ToString();
        rewardText.text = missionData.reward.ToString();
    }

    public void testLog()
    {
        Debug.Log("Ping");
    }

    public void StartLevel()
    {//load in string levelname here some way
        GameManager.Instance.LoadLevel("");
    }
}
