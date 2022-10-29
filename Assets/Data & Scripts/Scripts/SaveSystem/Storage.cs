using UnityEngine;

public static class Storage
{
    private const string Data = nameof(Data);

    private static PlayerData _playerData;

    public static PlayerData Load()
    {
        _playerData ??= new PlayerData();

        if (PlayerPrefs.HasKey(Data))
        {
            var serialized = PlayerPrefs.GetString(Data);
            _playerData = JsonUtility.FromJson<PlayerData>(serialized);
        }
        else
        {
            Save(new PlayerData());
        }

        return _playerData;
    }

    public static void Save(PlayerData playerData)
    {
        _playerData = playerData;
        var serialized = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString(Data, serialized);
    }
}