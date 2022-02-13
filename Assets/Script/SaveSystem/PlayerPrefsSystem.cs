using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSystem : ISaveSystem
{
    private const string NAME_KEY = "m_name";

    public void Save(SaveData data)
    {
        PlayerPrefs.SetString(NAME_KEY, data.PlayerName);
        PlayerPrefs.Save();
    }

    public SaveData Load()
    {
        var result = new SaveData();

        if (PlayerPrefs.HasKey(NAME_KEY))
        {
            result.PlayerName = PlayerPrefs.GetString(NAME_KEY);
        }

        return result;
    }
}