using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string levelToStart = "ExpansionMap";
    [SerializeField] Animation _mainmenuAnimator;
    [SerializeField] AnimationClip _fadeOutAnimation;
    [SerializeField] AnimationClip _fadeInAnimation;

    void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    public void OnFadeInComplete()
    {
        GameManager.Instance.LoadLevel(levelToStart);
        FadeOut();
    }

    public void OnFadeOutComplete()
    {
        GameManager.Instance.Unloadlevel("StartMenu");
        gameObject.SetActive(false);
    }

    public void FadeIn()
    {
        _mainmenuAnimator.Stop();
        _mainmenuAnimator.clip = _fadeInAnimation;
        _mainmenuAnimator.Play();
    }

    public void FadeOut()
    {
        _mainmenuAnimator.Stop();
        _mainmenuAnimator.clip = _fadeOutAnimation;
        _mainmenuAnimator.Play();

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(previousState == GameManager.GameState.PREGAME && currentState == GameManager.GameState.RUNNING)
        {
            FadeOut();
        }
    }
}

