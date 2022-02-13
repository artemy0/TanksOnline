using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyConnecter : MonoBehaviourPunCallbacks
{
    public event Action OnPlayerConnectedToMaster;

    public void Init(SaveData saveData)
    {
        //settings
        PhotonNetwork.NickName = saveData.PlayerName != null ? saveData.PlayerName : "Player";
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = Application.version;

        PhotonNetwork.ConnectUsingSettings();
    }


    public void StartGame()
    {
        //PhotonNetwork.JoinRandomOrCreateRoom(null, 2);
        ConnectRoom();
    }

    private void CreateRoom()
    {
        Photon.Realtime.RoomOptions roomoptions =
            new Photon.Realtime.RoomOptions()
            {
                MaxPlayers = 2
            };

        PhotonNetwork.CreateRoom(null, roomoptions);
    }

    private void ConnectRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }


    public override void OnConnectedToMaster()
    {
        //can create or joint rooom, becouse connect to server
        OnPlayerConnectedToMaster?.Invoke();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("JoinRandomRoom complete.");

        //move to gameplay scene, becouse we faund room
        PhotonNetwork.LoadLevel("GameScene");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"OnJoinRandomFailed code: {returnCode}. message: {message}");

        //create room, becouse another room do not exist
        switch (returnCode)
        {
            //No match found
            case 32760:
                CreateRoom();
                break;
        }
    }
}