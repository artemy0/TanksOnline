using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : BaseMenu
{
    public event Action OnLeaveRoomButtonClicked;

    [SerializeField] private Button _leaveRoomButton;


    private void Awake()
    {
        _leaveRoomButton.onClick.AddListener(LeaveRoomButtonClick);
    }


    private void LeaveRoomButtonClick()
    {
        OnLeaveRoomButtonClicked?.Invoke();
    }
}
