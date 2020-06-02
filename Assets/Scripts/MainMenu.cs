using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]Animation _mainmenuAnimator;
    [SerializeField]AnimationClip _fadeOutAnimation;
    [SerializeField]AnimationClip _fadeInAnimation;

    public void OnFadeOutComplete()
    {
        GameManager.Instance.LoadLevel("TheShore");
        FadeIn();
    }

    public void OnFadeInComplete()
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
}

