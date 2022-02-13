using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyInstaller : MonoBehaviour
{
    [SerializeField] private LobbyMenu _lobbyMenu;
    [SerializeField] private LobbyConnecter _lobbyConnecter;

    private ISaveSystem _saveSystem;
    private SaveData _saveData;


    private void Awake()
    {
        InstallSaveSystem();
        InstallConnecter();

        InstallMenu();
    }
    private void OnDestroy()
    {
        UninstallSaveSystem();
        UninstallConnecter();

        UninstallMenu();
    }


    private void InstallSaveSystem()
    {
        _saveSystem = new PlayerPrefsSystem();
        _saveData = _saveSystem.Load();
    }
    private void UninstallSaveSystem()
    {
        _saveSystem.Save(_saveData);
    }


    private void InstallMenu()
    {
        _lobbyMenu.ChangePlayerData(_saveData);
        _lobbyMenu.ShowConnectingToMasterPanel();

        _lobbyMenu.OnPlayerNameEntered += _saveData.SetPlayerName;
        _lobbyMenu.OnStartButtonClicked += _lobbyConnecter.StartGame;
    }
    private void UninstallMenu()
    {
        _lobbyMenu.OnPlayerNameEntered -= _saveData.SetPlayerName;
        _lobbyMenu.OnStartButtonClicked -= _lobbyConnecter.StartGame;
    }


    private void InstallConnecter()
    {
        _lobbyConnecter.Init(_saveData);

        _lobbyConnecter.OnPlayerConnectedToMaster += _lobbyMenu.ShowStartPanel;
    }
    private void UninstallConnecter()
    {
        _lobbyConnecter.OnPlayerConnectedToMaster -= _lobbyMenu.ShowStartPanel;
    }
}
