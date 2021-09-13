using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject ScorePanel;
    public GameObject ModalCoinImage;
    public GameObject Dealer;

    public GameObject CardObject;
    private GameScript GameScript;

    private Vector3 CoinTarget;

    private void Awake()
    {
        GameScript = CardObject.GetComponent<GameScript>();

    }

    // Start is called before the first frame update
    void Start()
    {

        CoinTarget = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, CoinTarget, Time.deltaTime * 15);
    }

    public void ChangeState()
    {

        if (GameScript.ChoiseMade == true)
        {
            GameIsEnded();
        }
        else if (GameScript.BetMade == true)
        {
            OnBetMade();
        }
    }


    public void OnBetMade()
    {
        transform.position = ScorePanel.transform.position;
        CoinTarget = new Vector3(0,-1,-3);
    }

    public void GameIsEnded()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2.2f);

        transform.position = new Vector3(ModalCoinImage.transform.position.x, ModalCoinImage.transform.position.y, ModalCoinImage.transform.position.z - 1);

        if (GameScript.IsWin == true)
        {
            CoinTarget = ScorePanel.transform.position;
        }
        else
        {
            CoinTarget = Dealer.transform.position;
        }




    }
}
