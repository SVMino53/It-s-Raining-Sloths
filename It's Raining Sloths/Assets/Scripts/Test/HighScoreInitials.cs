using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HighScoreInitials : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI[] InitialsLetters = null;
    [SerializeField]
    TextMeshProUGUI PlayerScoreText = null;
    [SerializeField]
    KeyCode LeftButton = KeyCode.F;
    [SerializeField]
    KeyCode RightButton = KeyCode.G;
    [SerializeField]
    float BlinkingTime = 0.3f;
    [SerializeField]
    float ScrollCooldown = 0.5f;

    public long PlayerScore = 0L;

    char CurrentLetter = 'A';
    int InitialsLetterIndex = 0;
    TextMeshProUGUI CurrentInitialLetter;
    string Initials = "";
    float CurrentBlinkingTime = 0.0f;
    float CurrentScrollCooldown = 0.0f;
    bool DoDisable = false;

    // Start is called before the first frame update
    void Start()
    {
        if(GlobalVars.SpecialMode)
        {
            LeftButton = KeyCode.K;
            RightButton = KeyCode.J;
        }
        PlayerScore = (long)GlobalVars.PlayerScore;

        PlayerScoreText.text = PlayerScore.ToString();

        for (int n = 0; n < InitialsLetters.Length; n++)
        {
            InitialsLetters[n].text = "A";
        }

        CurrentInitialLetter = InitialsLetters[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (DoDisable)
        {
            enabled = false;
        }

        if (Input.GetKeyDown(LeftButton) && InitialsLetterIndex > 0)
        {
            CurrentInitialLetter.text = CurrentLetter.ToString();
            InitialsLetterIndex -= 1;
            CurrentInitialLetter = InitialsLetters[InitialsLetterIndex];
            CurrentLetter = CurrentInitialLetter.text[0];
        }
        else if (Input.GetKeyDown(RightButton) && InitialsLetterIndex < InitialsLetters.Length - 1)
        {
            CurrentInitialLetter.text = CurrentLetter.ToString();
            InitialsLetterIndex += 1;
            CurrentInitialLetter = InitialsLetters[InitialsLetterIndex];
            CurrentLetter = CurrentInitialLetter.text[0];
        }
        else if (Input.GetKeyDown(RightButton))
        {
            CurrentInitialLetter.text = CurrentLetter.ToString(); ;

            string Initials = GetInitials();
            
            gameObject.GetComponent<ScoreBoard>().AddHighScore(Initials, PlayerScore);

            DoDisable = true;

            SceneManager.LoadScene("Menu Scene");
        }

        if (CurrentBlinkingTime > BlinkingTime)
        {
            CurrentBlinkingTime = 0.0f;

            if (CurrentInitialLetter.text == "")
            {
                CurrentInitialLetter.text = CurrentLetter.ToString();
            }
            else
            {
                CurrentInitialLetter.text = "";
            }
        }

        CurrentBlinkingTime += Time.deltaTime;

        CurrentScrollCooldown += Input.GetAxis("Mouse X");

        if (CurrentScrollCooldown < 0.0f)
        {
            CurrentLetter++;

            if (CurrentLetter > 'Z')
            {
                CurrentLetter = 'A';
            }

            CurrentInitialLetter.text = CurrentLetter.ToString();

            CurrentScrollCooldown = ScrollCooldown;
        }
        else if (CurrentScrollCooldown > ScrollCooldown)
        {
            CurrentLetter--;

            if (CurrentLetter < 'A')
            {
                CurrentLetter = 'Z';
            }

            CurrentInitialLetter.text = CurrentLetter.ToString();

            CurrentScrollCooldown = 0.0f;
        }
    }

    public string GetInitials()
    {
        Initials = "";

        for(int n = 0; n < InitialsLetters.Length; n++)
        {
            if (InitialsLetters[n].text == "")
            {
                InitialsLetters[n].text = CurrentLetter.ToString();
            }
            Initials += InitialsLetters[n].text;
        }

        return Initials;
    }
}
