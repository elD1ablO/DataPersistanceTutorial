using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager instance;

    public TextMeshProUGUI currentPlayer;

    public string playerName;
    public InputField nameInput;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    public void PlayerNameInput()
    {
        playerName = nameInput.text;
        currentPlayer.text = "Player: " + playerName;
        Debug.Log("name- " + playerName);
    }

    /*[System.Serializable]
    class SaveData
    {
        public string lastPlayerName;
        public string lastScore;
    }

    public void SaveNameScore()
    {
        SaveData data = new SaveData();
        data.lastPlayerName = playerName;
        data.lastScore =

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            teamColor = data.teamColor;
        }
    }
    */
}
