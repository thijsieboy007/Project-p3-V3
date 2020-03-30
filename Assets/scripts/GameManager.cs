using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

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

    private int TimerValue0 = 120;
    private int TimerValue1 = 90;
    private int TimerValue2 = 60;

    private int easyNumber;
    private int mediumNumber;
    private int HardNumber;

    public int difficulty = 5;

    // Start is called before the first frame update
    void Start()
    {
        Updatescore(0);
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
    }

    // Als je op de easy knop drukt krijg je vragen uit de easyq lijt en als je op enter drukt gaat hij naar de volgende.
    public void Buttoneasy()
    {
        button(0);
        NextQuestion(easyq, ref easyNumber);
    }

    // Als je op de medium knop drukt krijg je vragen uit de mediumq lijt en als je op enter drukt gaat hij naar de volgende.
    public void Buttonmedium()
    {
        button(1);
        NextQuestion(mediumq,ref mediumNumber);
    }

    // Als je op de hard knop drukt krijg je vragen uit de hardq lijt en als je op enter drukt gaat hij naar de volgende.
    public void Buttonhard()
    {
        button(2);
        NextQuestion(hardq,ref HardNumber);
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
        Updatescore(0);
        score = 0;
    }


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
}

        
    