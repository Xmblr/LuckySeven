using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetScript : MonoBehaviour
{
    public int BetValue;
    public int BetStep;
    public int MinBetValue;

    private ScoreScript ScoreScript;

    private void Awake()
    {
        ScoreScript = GameObject.Find("Score").GetComponent<ScoreScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        if (int.Parse(GetComponent<Text>().text) > ScoreScript.ScoreValue)
        {
            BetValue = ScoreScript.ScoreValue;
        }
        GetComponent<Text>().text = BetValue.ToString();
    }

    public void ChangeBetValue(string value)
    {
        if (value == "minus" && BetValue > MinBetValue)
        {
            BetValue -= BetStep;
        }
        if (value == "plus" && BetValue < ScoreScript.ScoreValue)
        {
            BetValue += BetStep;
        }
        GetComponent<Text>().text = BetValue.ToString();
    }
}
