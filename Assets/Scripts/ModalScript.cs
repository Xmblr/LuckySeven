using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModalScript : MonoBehaviour
{
    //private GameScript GameScript;
    private BetScript BetScript;

    public GameObject Card;
    public Text BetText;
    public Text ScoreText;

    public GameObject Panel;
    public Text ModalResultText;
    public Text ModalResultScore;

    private void Awake()
    {
        //GameScript = Card.GetComponent<GameScript>();
        BetScript = BetText.GetComponent<BetScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        Panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameIsEnded()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);

        Panel.gameObject.SetActive(true);
        
    }

    public void SetModalValue(bool isWin, int result)
    {
        if (isWin)
        {
            ModalResultText.text = "YOU WIN!";
            ModalResultScore.text = "+ " + result;
        }
        else
        {
            ModalResultText.text = "YOU LOOSE!";
            ModalResultScore.text = "- " + result;
        }
    }


}
