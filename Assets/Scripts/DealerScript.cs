using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealerScript : MonoBehaviour
{
    public GameObject Card;
    private GameScript GameScript;

    private void Awake()
    {
        GameScript = Card.GetComponent<GameScript>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState()
    {
        

        if (GameScript.ChoiseMade)
        {
            if (GameScript.IsWin)
            {
                ChangeDealerText("Congratulations!");
            }
            else
            {
                ChangeDealerText("My condolences.");
            }
        }
        else if (GameScript.BetMade)
        {
            ChangeDealerText("Now \n Select your choise");
        }
        else if (GameScript.ScoreText.GetComponent<ScoreScript>().ScoreValue == 0)
        {
            ChangeDealerText("You have no money");
        }
        else
        {
            ChangeDealerText("Choose your BET \n Then click on card");
        }
    }

    private void ChangeDealerText(string text)
    {
        GetComponent<Text>().text = text;
    }
}
