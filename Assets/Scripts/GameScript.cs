using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    

    public GameObject StartPoint;
    public GameObject EmptyPoint;
    public GameObject EqualsPoint;
    public GameObject UpPoint;
    public GameObject DownPoint;

    private ChangeStatesHelper ChangeStatesHelper;

    public bool BetMade;
    public bool ChoiseMade;
    public bool IsWin;

    public Text ScoreText;
    private ScoreScript ScoreScript;

    public Text BetText;
    private BetScript BetScript;

    public GameObject MainCamera;
    private ModalScript ModalScript;

    private Vector3 CardTarget;

    public Sprite[] Cards;
    // Start is called before the first frame update

    private void Awake()
    {
        ChangeStatesHelper = GetComponent<ChangeStatesHelper>();
        ScoreScript = ScoreText.GetComponent<ScoreScript>();
        BetScript = BetText.GetComponent<BetScript>();
        ModalScript = MainCamera.GetComponent<ModalScript>();
    }
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        CardTarget = StartPoint.transform.position;
        transform.rotation = Quaternion.identity;
        IsWin = BetMade = ChoiseMade = false;
        
        
        ChangeStatesHelper.ChangeStates();
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
        if (!BetMade && ScoreScript.ScoreValue > 0)
        {
            OnBetMade();
        } 
    }

    public void OnBetMade()
    {
        BetMade = true;
        CardTarget = EmptyPoint.transform.position;
        ScoreScript.ScoreValue -= BetScript.BetValue;

        ChangeStatesHelper.ChangeStates();
    }

    public void OnChoiseMade(string option)
    {
        ChoiseMade = true;
        int randomCard = Random.Range(0, Cards.Length);
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Cards[randomCard];
        if (randomCard < 24)
        {
            CardTarget = DownPoint.transform.position;
            StartCoroutine(CheckOnWin("down", option, 2));
        }
        else if (randomCard > 23 && randomCard < 28)
        {
            CardTarget = EqualsPoint.transform.position;
            StartCoroutine(CheckOnWin("equals", option, 11));
        }
        else
        {
            CardTarget = UpPoint.transform.position;
            StartCoroutine(CheckOnWin("up", option, 2));
        }

        ChangeStatesHelper.ChangeStates();


    }

    IEnumerator CheckOnWin(string correctOption, string selectedOption, int payouts)
    {
        
        int result=0;
        if (selectedOption == correctOption)
        {
            IsWin = true;
            yield return new WaitForSeconds(2);
            result = BetScript.BetValue * payouts;
            ScoreScript.ScoreValue += result;
            
            // связь между логикой проверки выйгрыша с модальным окном
        }
        else
        {
            result = BetScript.BetValue;
        }

        ModalScript.SetModalValue(IsWin, result);
        ScoreScript.ChangeScoreValue();
    }



    
}

