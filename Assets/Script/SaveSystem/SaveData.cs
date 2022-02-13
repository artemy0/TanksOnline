using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public string PlayerName;

    public void SetPlayerName(string playerName)
    {
        PlayerName = playerName;
    }
}