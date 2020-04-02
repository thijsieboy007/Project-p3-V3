using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image questionImage;
    [SerializeField] private List<Question> easyq;
    [SerializeField] private List<Question> hardq;
    [SerializeField] private List<Question> mediumq;
    [SerializeField] private InputField answerfield;

    private int goodAnswers;
    private int score;

    public Button easy;
    public Button medium;
    public Button hard;
    public GameObject background;
    public GameObject img;
    public GameObject start;
    public GameObject text;
    public TextMeshProUGUI scoretext;
    public GameObject GameOverPanel;

    private int TimerValue0 = 12;
    private int TimerValue1 = 9;
    private int TimerValue2 = 6;
  
    public Text Timer;
    public Text EndScore;

    private int easyNumber;
    private int mediumNumber;
    private int HardNumber;

    public int difficulty = 5;

    // Start is called before the first frame update
    void Start()
    {
        Updatescore(0);
        
        easy.gameObject.SetActive(true);
        medium.gameObject.SetActive(true);
        hard.gameObject.SetActive(true);
        img.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
        start.gameObject.SetActive(true);
        text.gameObject.SetActive(false);
        scoretext.gameObject.SetActive(false);
        Timer.gameObject.SetActive(false);
        GameOverPanel.gameObject.SetActive(false);
    }

    public void Updatescore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoretext.text = "Score:" + score;
    }

    // dit zorgt ervoor dat er een random vraag met het bij behoorende plaatje uit de lijst word gehaalt en dat als die geweest
    // is die vraag verwijdert word zodat hij niet nog een keer voorkomt.
    private void NextQuestion(List<Question> questionList,ref int questionIndex){
        questionList.RemoveAt(questionIndex);
        questionIndex = Random.Range(0, questionList.Count);
        questionImage.sprite = questionList[questionIndex].picture;
        Debug.Log(questionList[questionIndex].answer);

        if (questionList == null || questionList.Count == 0)
        {
            gameover();
        }
    }

    // Als je op de easy knop drukt krijg je vragen uit de easyq lijt en als je op enter drukt gaat hij naar de volgende.
    public void Buttoneasy()
    {
        button(0);
        NextQuestion(easyq, ref easyNumber);
        countDownTimer0();
    }

    // Als je op de medium knop drukt krijg je vragen uit de mediumq lijt en als je op enter drukt gaat hij naar de volgende.
    public void Buttonmedium()
    {
        button(1);
        NextQuestion(mediumq,ref mediumNumber);
        countDownTimer1();
    }

    // Als je op de hard knop drukt krijg je vragen uit de hardq lijt en als je op enter drukt gaat hij naar de volgende.
    public void Buttonhard()
    {
        button(2);
        NextQuestion(hardq,ref HardNumber);
        countDownTimer2();
    }

    // dit zorgt ervoor dat de juiste objecten zichtbaar worden zodat als je op een knop drukt je niet op het main menu blijft.
    private void button(int difficultyCount)
    {
        difficulty = difficultyCount;
        easy.gameObject.SetActive(false);
        medium.gameObject.SetActive(false);
        hard.gameObject.SetActive(false);
        img.gameObject.SetActive(true);
        background.gameObject.SetActive(true);
        start.gameObject.SetActive(false);
        text.gameObject.SetActive(true);
        scoretext.gameObject.SetActive(true);
        Timer.gameObject.SetActive(true);
        GameOverPanel.gameObject.SetActive(false);
        Updatescore(0);
        score = 0;
    }

    //checkt het antwoord klopt of niet, update de score en gaat naar de volgende vraag
    public void CheckAnswer()
    {
        if (difficulty == 0)
        {
            var b = answerfield.text == easyq[easyNumber].answer;
            string s = b ? "juist" : "onjuist";
            Debug.Log($"U ingevulde antwoord is {s}");
            if (b)
            {
                Updatescore(25);
            }
            else
            {
                Updatescore(-5);
            }
            NextQuestion(easyq,ref easyNumber);    
        }

        if (difficulty == 1)
        {
            var b = answerfield.text == mediumq[mediumNumber].answer;
            string s = b ? "juist" : "onjuist";
            Debug.Log($"U ingevulde antwoord is {s}");
            if (b)
            {
                Updatescore(20);
            }
            else
            {
                Updatescore(-10);
            }
            NextQuestion(mediumq,ref mediumNumber);
        }

        if (difficulty == 2)
        {
            var b = answerfield.text == hardq[HardNumber].answer;
            string s = b ? "juist" : "onjuist";
            Debug.Log($"U ingevulde antwoord is {s}");
            if (b)
            {
                Updatescore(20);
            }
            else
            {
                Updatescore(-20);
            }
            NextQuestion(hardq,ref HardNumber);
        }

        answerfield.text = "";
    }
    //dit zijn de timers
    void countDownTimer0()
    {
        if (TimerValue0 > 0)
        {
            Timer.text = "Time : " + TimerValue0;
            TimerValue0--;
            Invoke("countDownTimer0", 1.0f);
        }
        else
        {
            gameover();
        }
    }
    
    void countDownTimer1()
    {
        if (TimerValue1 > 0)
        {
            Timer.text = "Time : " + TimerValue1;
            TimerValue1--;
            Invoke("countDownTimer1", 1.0f);
        }
        else
        {
            gameover();
        }
    }
    
    void countDownTimer2()
    {
        if (TimerValue2 > 0)
        {
            Timer.text = "Time : " + TimerValue2;
            TimerValue2--;
            Invoke("countDownTimer2", 1.0f);
        }
        else
        {
            gameover();
        }
    }

    void gameover()
    {
        GameOverPanel.gameObject.SetActive(true);
        easy.gameObject.SetActive(false);
        medium.gameObject.SetActive(false);
        hard.gameObject.SetActive(false);
        img.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
        start.gameObject.SetActive(false);
        text.gameObject.SetActive(true);
        scoretext.gameObject.SetActive(false);
        Timer.gameObject.SetActive(false);

        //clear the console 
        var logEntries = System.Type.GetType("UnityEditor.LogEntries, UnityEditor.dll");
        var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        clearMethod.Invoke(null, null);
        
        EndScore.text = scoretext.text;
    }

    //start opnieuw
    public void TryAgain()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }
}

        
    