using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class SaveManager : MonoBehaviour {
    [System.Serializable] public struct HighScore {
        public string nickName;
        public float score;
    }

    [SerializeField] private bool _writeHighScores = false;
    [SerializeField] private TMP_Text _highScoresText;
    [SerializeField] private int _maxHighScoresNumber = 3;
    [SerializeField] private List<HighScore> _highScores = new List<HighScore>();

    private void Start() {
        LoadJsonData();
        if(_writeHighScores) WriteHighScores();
    }

    private void SaveJsonData() {
        FileManager.WriteToFile("SaveData.dat", ToJson());
    }

    private void LoadJsonData() {
        if(FileManager.LoadFromFile("SaveData.dat", out var json)) {
            LoadFromJson(json);
        }
    }

    public void UpdateHighScores(string nickName, float score) {
        int position = GetPosition(score);

        if(_highScores.Count < _maxHighScoresNumber) {
            HighScore highScore = new HighScore();
            _highScores.Add(highScore);
        }
        
        for(int i = _highScores.Count - 1; i >= position; i--) {
            if(i > position) {
                _highScores[i] = _highScores[i-1];
            } else {
                HighScore highScore = new HighScore();
                highScore.nickName = nickName;
                highScore.score = score;
                _highScores[i] = highScore;
            }
        }

        SaveJsonData();
    }

    private int GetPosition(float score) {
        for(int i = 0; i < _highScores.Count; i++) {
            if(_highScores[i].score > score) return i;
        }
        return _highScores.Count;
    }

    private string ToJson() {
        string a = "{\n\"_highScores\":[\n";
        for(int i = 0; i < _highScores.Count; i++) {
            a = string.Concat(a, JsonUtility.ToJson(_highScores[i], true));
            if(i != _highScores.Count-1) a = string.Concat(a, ",\n");
            a = string.Concat(a, "\n");
        }
        a = string.Concat(a, "]\n}");
        return a;
    }

    private void LoadFromJson(string a_Json) {
        JsonUtility.FromJsonOverwrite(a_Json, this);
    }

    private void WriteHighScores() {
        int i;
        string scoresText = "";

        for(i = 0; i < _highScores.Count; i++) {
            scoresText = string.Concat(scoresText, "Top " + i + ": " + _highScores[i].nickName + " - " + _highScores[i].score + "s\n");
        }
        for(i = i; i < _maxHighScoresNumber; i++) {
            scoresText = string.Concat(scoresText, "Top " + i + ": Ainda não alcançado\n");
        }
        
        _highScoresText.SetText(scoresText);
    }
}