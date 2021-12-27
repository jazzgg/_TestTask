using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndScreen : MonoBehaviour, IResumeEventProvider, IPauseable 
{ 
    public event Action OnResume;

    [SerializeField]
    private GameObject _panel;
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private Button _exitButton;

    public void Initialize()
    {
        _restartButton.onClick.AddListener(RestartGame);
        _exitButton.onClick.AddListener(ExitGame);

        SetPanelActive(false);
    }
    public void Pause()
    {
        SetPanelActive(true);   
    }

    public void Resume()
    {
        SetPanelActive(false);
    }
    private void RestartGame()
    {
        OnResume?.Invoke();
    }
    private void ExitGame()
    {
        Application.Quit();
    }
    private void SetPanelActive(bool active)
    {
        _panel.SetActive(active);
    }
    private void OnDestroy()
    {
        _restartButton.onClick.RemoveListener(RestartGame);
        _exitButton.onClick.RemoveListener(ExitGame);
    }

}
