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

    public int bestScore;
    public string bestPlayerName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadNameScore();
    }

    public void PlayerNameInput()
    {
        playerName = nameInput.text;
        currentPlayer.text = "Player: " + playerName;        
    }

    [System.Serializable]
    class SaveData
    {
        public string _bestPlayerName;
        public int _bestScore;
    }

    public void SaveNameScore()
    {
        SaveData data = new SaveData();
        data._bestPlayerName = playerName;
        data._bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadNameScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data._bestPlayerName;
            bestScore = data._bestScore;
        }
    }
    
}
