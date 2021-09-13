using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStatesHelper : MonoBehaviour
{
    

    public GameObject Coin;
    private CoinManager CoinManager;

    public GameObject Score;
    private ScoreScript ScoreScript;

    //public GameObject Bet;
    //private BetScript BetScript;

    public Text DealerText;
    private DealerScript DealerScript;

    //private GameScript GameScript;
    private ButtonHelper ButtonHelper;


    // Start is called before the first frame update
    void Awake()
    {
       
        CoinManager = Coin.GetComponent<CoinManager>();
        ScoreScript = Score.GetComponent<ScoreScript>();
        //BetScript = Bet.GetComponent<BetScript>();
        //GameScript = GetComponent<GameScript>();
        ButtonHelper = GetComponent<ButtonHelper>();
        DealerScript = DealerText.GetComponent<DealerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeStates()
    {
        ScoreScript.ChangeScoreValue();
        ButtonHelper.ChangeState();
        DealerScript.ChangeState();
        CoinManager.ChangeState();
        
    }
}
