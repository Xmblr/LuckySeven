using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public GameObject EmptyPoint;
    public GameObject EqualsPoint;
    public GameObject UpPoint;
    public GameObject DownPoint;


    public bool BetMade = false;
    public bool ChoiseMade = false;

    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        target = transform.position;
        ChangeDealerText("Choose your BET \n Then click on card");

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * 5);
    }

    private void OnMouseDown()
    {

        OnBetSelected();

    }

    public void OnBetSelected()
    {
        BetMade = true;
        target = EmptyPoint.transform.position;
    }

    public void OnOptionSelected(string option)
    {
        ChoiseMade = true;
        switch(option)
        {
            case "equals": Debug.Log("equals7 selected"); break;
            case "up": Debug.Log("up7 selected"); break;
            case "down": Debug.Log("down7 selected"); break;

        }
    }




    private void ChangeDealerText(string text)
    {
        GameObject.Find("DealerText").GetComponent<Text>().text = text;
    }
}
