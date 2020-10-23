using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] MissionDetails missionData;

    [System.Serializable]
    public struct MissionDetails
    {
        public enum Difficulty
        {
            Easy,
            Normal,
            Hard,
            Insane
        }
        public Difficulty diff;
        public int reward;
        public WaveData[] Waves;

    }

    void OnMouseDown()
    {
        ExpansionMapManager.Instance.LoadMissionPrefab(transform.position, missionData);
    }




}
