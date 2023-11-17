using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveManager : MonoBehaviour {
    [System.Serializable] public struct HighScore {
        public string nickName;
        public float score;
    }

    public static int _maxHighScoresNumber = 3;
    public List<HighScore> highScores = new List<HighScore>();

    private static void SaveJsonData(SaveManager a_SaveManager) {
        if(FileManager.WriteToFile("SaveData.dat", a_SaveManager.ToJson())) Debug.Log("Saved");
    }

    private static void LoadJsonData(SaveManager a_SaveManager) {
        if(FileManager.LoadFromFile("SaveData.dat", out var json)) {
            a_SaveManager.LoadFromJson(json);
            Debug.Log("Loaded");
        }
    }

    private void UpdateHighScores(string nickName, float score) {
        int position = GetPosition(score);

        if(highScores.Count < _maxHighScoresNumber) {
            HighScore highScore = new HighScore();
            highScores.Add(highScore);
        }
        
        for(int i = highScores.Count - 1; i >= position; i--) {
            if(i > position) {
                highScores[i] = highScores[i-1];
            } else {
                HighScore highScore = new HighScore();
                highScore.nickName = nickName;
                highScore.score = score;
                highScores[i] = highScore;
            }
        }
        Debug.Log("Updated");
    }

    private int GetPosition(float score) {
        for(int i = 0; i < highScores.Count; i++) {
            if(highScores[i].score > score) return i;
        }
        return highScores.Count;
    }

    public string ToJson() {
        string a = "{\n\"highScores\":[\n";
        for(int i = 0; i < highScores.Count; i++) {
            a = string.Concat(a, JsonUtility.ToJson(highScores[i], true));
            if(i != highScores.Count-1) a = string.Concat(a, ",\n");
            a = string.Concat(a, "\n");
        }
        a = string.Concat(a, "]\n}");
        return a;
    }

    public void LoadFromJson(string a_Json) {
        JsonUtility.FromJsonOverwrite(a_Json, this);
    }

    public void Save() {
        SaveJsonData(this);
    }

    public void Load() {
        LoadJsonData(this);
    }

    public void Upload() {
        UpdateHighScores("QIJO", 30);
        UpdateHighScores("FRST", 20);
        UpdateHighScores("ABRT", 40);
        UpdateHighScores("CRLS", 50);
        UpdateHighScores("FDRC", 10);
    }
}
