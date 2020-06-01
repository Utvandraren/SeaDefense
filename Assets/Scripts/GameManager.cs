using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private string _currentLevelName = string.Empty;

    List<AsyncOperation> _loadOperations;
    private List<GameObject> _instancedSystemPrefabs;

    public GameObject[] SystemPrefabs;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        _instancedSystemPrefabs = new List<GameObject>();
        _loadOperations = new List<AsyncOperation>();

        InstantiateSystemPrefabs();
    }

    void OnLoadOperationComplete(AsyncOperation ao)
    {
        if (_loadOperations.Contains(ao))
        {
            _loadOperations.Remove(ao);            
        }
        Debug.Log("Completed loading");
    }

    void OnUnloadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("Completed unloading");
    }

    void InstantiateSystemPrefabs()
    {
        GameObject prefabInstance;
        for (int i = 0; i < SystemPrefabs.Length; i++)
        {
            prefabInstance = Instantiate(SystemPrefabs[i]);
            _instancedSystemPrefabs.Add(prefabInstance);
        }
    }

    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName,LoadSceneMode.Additive);
        if(ao == null)
        {
            Debug.LogError("unable to load level");
            return;
        }
        ao.completed += OnLoadOperationComplete;
        _loadOperations.Add(ao);
        _currentLevelName = levelName;
    }

    public void Unloadlevel(string levelname)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelname);
        if (ao == null)
        {
            Debug.LogError("unable to unload level");
            return;
        }
        ao.completed += OnUnloadOperationComplete;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        for (int i = 0; i < _instancedSystemPrefabs.Count; i++)
        {
            Destroy(_instancedSystemPrefabs[i]);
        }
        _instancedSystemPrefabs.Clear();
    }

    public void Win()
    {
        //UImanager.triggerWinPicture   Trigger Win Animation
        UIManager.Instance.ToogleWinUI();
    }
}
