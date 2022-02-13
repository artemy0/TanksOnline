using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] private GameMenu _gameMenu;
    [SerializeField] private GameConnecter _gameConnecter;


    private void Awake()
    {
        InstallConnecter();

        InstallMenu();
    }
    private void OnDestroy()
    {
        UninstallConnecter();

        UninstallMenu();
    }


    private void InstallMenu()
    {
        _gameMenu.OnLeaveRoomButtonClicked += _gameConnecter.LeaveRoom;
    }
    private void UninstallMenu()
    {
        _gameMenu.OnLeaveRoomButtonClicked -= _gameConnecter.LeaveRoom;
    }


    private void InstallConnecter()
    {
        _gameConnecter.Init();
    }
    private void UninstallConnecter()
    {
    }
}
