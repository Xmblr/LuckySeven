using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    private ModalScript ModalScript;

    public GameObject EmptyPoint;
    public GameObject EqualsPoint;
    public GameObject UpPoint;
    public GameObject DownPoint;


    public bool BetMade;
    public bool ChoiseMade;
    public bool IsWin;

    private Vector3 CardTarget;

    public Sprite[] Cards;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        ModalScript = GameObject.Find("ModalPanel").GetComponent<ModalScript>();
        
    }

    public void StartGame()
    {
        CardTarget = transform.position;
        IsWin = BetMade = ChoiseMade = false;
        ChangeDealerText("Choose your BET \n Then click on card");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, CardTarget, Time.deltaTime * 5);
        if (ChoiseMade == true)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * 5);
    }

    private void OnMouseDown()
    {
        OnBetMade();
    }

    public void OnBetMade()
    {
        BetMade = true;
        CardTarget = EmptyPoint.transform.position;
        ChangeDealerText("Now \n Select your choise");
    }

    public void OnChoiseMade(string option)
    {
        ChoiseMade = true;
        int randomCard = Random.Range(0, Cards.Length);
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Cards[randomCard];
        if (randomCard < 19)
        {
            CardTarget = DownPoint.transform.position;
            CheckOnWin("down", option);
        }
        else if (randomCard > 19 && randomCard < 24)
        {
            CardTarget = EqualsPoint.transform.position;
            CheckOnWin("equals", option);
        }
        else
        {
            CardTarget = UpPoint.transform.position;
            CheckOnWin("up", option);
        }

    
    }

    public void CheckOnWin(string correctOption, string selectedOption)
    {
        if (correctOption == selectedOption)
        {
            IsWin = true;
            ChangeDealerText("Congratulations!");
        }
        else
        {
            ChangeDealerText("My condolences.");
        }
        ModalScript.GameIsEnded(IsWin);
    }



    private void ChangeDealerText(string text)
    {
        GameObject.Find("DealerText").GetComponent<Text>().text = text;
    }
}

