using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : Singleton<WaveManager>
{
    [SerializeField] WaveData[] Waves;
    [Range(0.01f,1f)][SerializeField] float probabilityForWave;
    [HideInInspector]
    public Transform enemyTarget;

    private int currentWave;

    // Start is called before the first frame update
    void Start()
    {
        currentWave = 0;
        enemyTarget = FindObjectOfType<PlayerHealth>().transform;
        StartCoroutine(CheckProbToStart());
    }

    /// <summary>
    /// CoRoutine checking if the the wave is starting and then start
    /// </summary>
    /// <returns></returns>
    IEnumerator CheckProbToStart()
    {
        bool coRoutRunning;
        coRoutRunning = true;

        while (coRoutRunning)
        {
            yield return new WaitForSeconds(3.0f);

            if (Random.Range(0.01f, 1f) < probabilityForWave)
            {
                Debug.Log("WaveReleased");
                coRoutRunning = false;
                StartCoroutine(StartWave());
            }
        }
    }

    /// <summary>
    /// Instantiate enemies for the current wave to the map
    /// </summary>
    IEnumerator StartWave()
    {
        GameObject[] enemiesToInstantiate;
        enemiesToInstantiate = Waves[currentWave].GetEnemies().ToArray();

        for (int i = 0; i < enemiesToInstantiate.Length; i++)
        {
            yield return new WaitForSeconds(3.0f);
            Instantiate(enemiesToInstantiate[i]);
        }

        if (++currentWave > Waves.Length)
        {
            GameManager.Instance.Win();
        }

        StartCoroutine(CheckProbToStart());
    }
}

    
    

