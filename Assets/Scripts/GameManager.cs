using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[System.Serializable]
public class EventgameState : UnityEvent<GameManager.GameState, GameManager.GameState> { }

public class GameManager : Singleton<GameManager>
{
    private string _currentLevelName = string.Empty;

    List<AsyncOperation> _loadOperations;
    private List<GameObject> _instancedSystemPrefabs;

    public GameObject[] SystemPrefabs;

    public EventgameState OnGameStateChanged;

    public enum GameState
    {
        PREGAME,
        RUNNING,
        PAUSED
    }

    GameState _currentgameState = GameState.PREGAME;

    public GameState CurrentGameState
    {
        get { return _currentgameState;  }
        private set { _currentgameState = value; }
    }
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        _instancedSystemPrefabs = new List<GameObject>();
        _loadOperations = new List<AsyncOperation>();

        InstantiateSystemPrefabs();

        LoadLevel("StartMenu");
    }

    void OnLoadOperationComplete(AsyncOperation ao)
    {
        if (_loadOperations.Contains(ao))
        {
            _loadOperations.Remove(ao); 
            
            //if(_loadOperations.Count == 0)
            //{
            //    UpdateState(GameState.RUNNING);
            //}
        }
        //Debug.Log("Completed loading");
    }

    void OnUnloadOperationComplete(AsyncOperation ao)
    {
        //Debug.Log("Completed unloading");
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

    void UpdateState(GameState state)
    {
        GameState previousGameState = _currentgameState;
        _currentgameState = state;

        switch (_currentgameState)
        {
            case GameState.PREGAME:
                break;

            case GameState.RUNNING:
                break;

            case GameState.PAUSED:
                break;

            default:
                break;
        }


        OnGameStateChanged.Invoke(_currentgameState, previousGameState);
    }

    public void StartGame()
    {
        LoadLevel("TheShore");
    }
}
