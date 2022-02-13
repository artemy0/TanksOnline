using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMenu : BaseMenu
{
    public event Action<string> OnPlayerNameEntered;
    public event Action OnStartButtonClicked;

    [SerializeField] private TMP_InputField _playerNameInputField;
    [SerializeField] private RectTransform _connectingPanel;
    [SerializeField] private Button _startButton;


    private void Awake()
    {
        _playerNameInputField.onEndEdit.AddListener(PlayerNameEnter);
        _startButton.onClick.AddListener(StartButtonClick);
    }


    public void ChangePlayerData(SaveData saveData)
    {
        _playerNameInputField.text = saveData.PlayerName;
    }


    private void PlayerNameEnter(string playerName)
    {
        OnPlayerNameEntered?.Invoke(playerName);
    }
    private void StartButtonClick()
    {
        OnStartButtonClicked?.Invoke();
    }


    public void ShowConnectingToMasterPanel()
    {
        _connectingPanel.gameObject.SetActive(true);
        _startButton.gameObject.SetActive(false);
    }
    public void ShowStartPanel()
    {
        _connectingPanel.gameObject.SetActive(false);
        _startButton.gameObject.SetActive(true);
    }
}
