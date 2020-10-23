using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "new Wave")]
public class WaveData : ScriptableObject
{
    [SerializeField] EnemyWaveData[] enemies;

    public List<GameObject> GetEnemies()
    {
        List<GameObject> enmyToReturn;
        enmyToReturn = new List<GameObject>();
        
        for (int i = 0; i < enemies.Length; i++)
        {
            for (int j = 0; j < enemies[i].amountOfEnemies; j++)
            {
                enmyToReturn.Add(enemies[i].enemy);
            }
        }
        return enmyToReturn;
    }
    
}
