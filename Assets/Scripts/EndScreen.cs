using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndScreen : MonoBehaviour, IResumeEventProvider, IStopable, IRestartable
{ 
    public event Action OnResume;

    private IStatsProvider _statsProvider;
    [SerializeField]
    private GameObject _panel;
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private Button _exitButton;
    [SerializeField]
    private Text _timer;
    

    public void Initialize(IStatsProvider statsProvider)
    {
        _statsProvider = statsProvider;
        _restartButton.onClick.AddListener(RestartGame);
        _exitButton.onClick.AddListener(ExitGame);

        SetPanelActive(false);
    }
    public void Stop()
    {
        _timer.text = _statsProvider.SpentTime.ToString();
      
        SetPanelActive(true);
    }
    public void Restart()
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
