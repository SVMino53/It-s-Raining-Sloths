using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class ScoreBoard : MonoBehaviour
{
    struct HighScore
    {
        public HighScore(int rank, string init, long score)
        {
            Rank = rank;
            Initials = init;
            Score = score;
        }
        public int Rank;
        public string Initials;
        public long Score;
    }

    [SerializeField]
    TextMeshProUGUI[] ScoreTexts = null;
    [SerializeField]
    string[] PresetInitials = null;
    [SerializeField]
    long[] PresetScore = null;
    [SerializeField]
    bool Reset = false;

    HighScore[] PresetHighScores;
    HighScore[] HighScores;

    string Path = @"..\MyTest.txt";

    // Start is called before the first frame update
    void Start()
    {
        PresetHighScores = new HighScore[10];
        HighScores = new HighScore[10];

        if (Reset || !File.Exists(Path))
        {
            ResetHighScores();
        }

        GetHighScores();
    }

    public void ResetHighScores()
    {
        for (int n = 0; n < PresetInitials.Length; n++)
        {

            PresetHighScores[n] = new HighScore(n + 1, PresetInitials[n], PresetScore[n]);
        }

        File.Delete(Path);

        using (StreamWriter sw = File.CreateText(Path))
        {
            for (int n = 0; n < PresetHighScores.Length; n++)
            {
                sw.WriteLine((n + 1).ToString() + "\n");
                sw.WriteLine(PresetHighScores[n].Initials + "\n");
                sw.WriteLine(PresetHighScores[n].Score.ToString() + "\n");
            }
        }

        Reset = false;
    }

    public void SetHighScores()
    {
        using (StreamWriter sw = File.CreateText(Path))
        {
            for (int n = 0; n < PresetHighScores.Length; n++)
            {
                sw.WriteLine((n + 1).ToString() + "\n");
                sw.WriteLine(HighScores[n].Initials + "\n");
                sw.WriteLine(HighScores[n].Score.ToString() + "\n");
            }
        }
    }

    public void GetHighScores()
    {
        using (StreamReader sr = File.OpenText(Path))
        {
            string s;
            int index = 0;
            while ((s = sr.ReadLine()) != null)
            {
                char c = (char)sr.Peek();

                if (s == "")
                {
                    index++;
                }
                else
                {
                    switch (index % 3)
                    {
                        case 0:
                            HighScores[index / 3].Rank = int.Parse(s);
                            break;
                        case 1:
                            HighScores[index / 3].Initials = s;
                            break;
                        case 2:
                            HighScores[index / 3].Score = long.Parse(s);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        for (int n = 0; n < HighScores.Length; n++)
        {
            ScoreTexts[n].text = HighScores[n].Rank.ToString();
            ScoreTexts[n].text += ". ";
            ScoreTexts[n].text += HighScores[n].Initials;
            ScoreTexts[n].text += " - ";
            ScoreTexts[n].text += HighScores[n].Score.ToString();
        }
    }

    public void AddHighScore(string init, long score)
    {
        for (int n = HighScores.Length - 1; n >= 0; n--)
        {
            if (score > HighScores[n].Score)
            {
                if (n != HighScores.Length - 1)
                {
                    HighScores[n + 1] = HighScores[n];
                }
                HighScores[n] = new HighScore(n + 1, init, score);
            }
            else break;
        }

        SetHighScores();
        GetHighScores();
    }
}
