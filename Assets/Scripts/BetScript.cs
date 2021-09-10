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
    private MenuScript MenuScript;
    // Start is called before the first frame update
    void Start()
    {
        ScoreScript = GameObject.Find("Score").GetComponent<ScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
