using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image questionImage;
    [SerializeField] private List<Question> easyq;
    [SerializeField] private List<Question> hardq;
    [SerializeField] private List<Question> mediumq;
    [SerializeField] private InputField answerfield;

    private int goodAnswers;

    public Button easy;
    public Button medium;
    public Button hard;
    public GameObject background;
    public GameObject img;
    public GameObject start;
    public GameObject text;

    private bool easyerror;
    private bool mediumerror;
    private bool harderror;

    private int easyNumber;
    private int mediumNumber;
    private int HardNumber;

    public int difficulty = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void NextQuestion0()
    {
        easyq.RemoveAt(easyNumber);
        easyNumber = Random.Range(0, easyq.Count);
        questionImage.sprite = easyq[easyNumber].picture;
        Debug.Log(easyq[easyNumber].answer);
    }

    void NextQuestion1()
    {
        mediumq.RemoveAt(mediumNumber);
        mediumNumber = Random.Range(0, mediumq.Count);
        questionImage.sprite = mediumq[mediumNumber].picture;
        Debug.Log(mediumq[mediumNumber].answer);
    }

    void NextQuestion2()
    {
        hardq.RemoveAt(HardNumber);
        HardNumber = Random.Range(0, hardq.Count);
        questionImage.sprite = hardq[HardNumber].picture;
        Debug.Log(hardq[HardNumber].answer);
    }

    public void Buttoneasy()
    {
        difficulty = 0;
        
        easy.gameObject.SetActive(false);
        medium.gameObject.SetActive(false);
        hard.gameObject.SetActive(false);
        img.gameObject.SetActive(true);
        background.gameObject.SetActive(true);
        start.gameObject.SetActive(false);
        text.gameObject.SetActive(true);
        
        easyerror = false;
        easyNumber = Random.Range(0, easyq.Count);
        questionImage.sprite = easyq[easyNumber].picture;
        Debug.Log(easyq[easyNumber].answer);
    }

    public void Buttonmedium()
    {
        difficulty = 1;
        easy.gameObject.SetActive(false);
        medium.gameObject.SetActive(false);
        hard.gameObject.SetActive(false);
        img.gameObject.SetActive(true);
        background.gameObject.SetActive(true);
        start.gameObject.SetActive(false);
        text.gameObject.SetActive(true);
        mediumerror = false;
        mediumNumber = Random.Range(0, easyq.Count);
        questionImage.sprite = mediumq[mediumNumber].picture;
        Debug.Log(mediumq[mediumNumber].answer);
    }

    public void Buttonhard()
    {
        difficulty = 2;
        easy.gameObject.SetActive(false);
        medium.gameObject.SetActive(false);
        hard.gameObject.SetActive(false);
        img.gameObject.SetActive(true);
        background.gameObject.SetActive(true);
        start.gameObject.SetActive(false);
        text.gameObject.SetActive(true);
        harderror = false;
        HardNumber = Random.Range(0, hardq.Count);
        questionImage.sprite = hardq[HardNumber].picture;
        Debug.Log(hardq[HardNumber].answer);
    }

    public void CheckAnswer()
    {
        if (answerfield.text == easyq[easyNumber].answer && difficulty == 0)
        {
            Debug.Log("U ingevulde antwoord is juist");
            NextQuestion0();
            easyerror = true;
            answerfield.text = "";
        }
        else if (easyerror)
        {
            Debug.Log("U ingevulde antwoord is onjuist");
            NextQuestion0();
            answerfield.text = "";

        }

        if (answerfield.text == mediumq[mediumNumber].answer && difficulty == 1)
        {
            Debug.Log("U ingevulde antwoord is juist");
            NextQuestion1();
            answerfield.text = "";
            mediumerror = true;
        }
        else if (mediumerror)
        {
            Debug.Log("U ingevulde antwoord is onjuist");
            NextQuestion1();
            answerfield.text = "";

        }

        if (answerfield.text == hardq[HardNumber].answer && difficulty == 2)
        {
            Debug.Log("U ingevulde antwoord is juist");
            NextQuestion2();
            answerfield.text = "";
            harderror = true;
        }
        else if (harderror)
        {
            Debug.Log("U ingevulde antwoord is onjuist");
            NextQuestion2();
            answerfield.text = "";

        }
    }
} 
        
    