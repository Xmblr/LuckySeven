using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHelper : MonoBehaviour
{
    public GameObject CardObject;
    private GameScript GameScript;
    // Start is called before the first frame update
    void Start()
    {
        GameScript = CardObject.GetComponent<GameScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // when choise made
        if (GameScript.ChoiseMade == true)
        {
            ButtonInteractable("Equals7", false);
            ButtonInteractable("Up7", false);
            ButtonInteractable("Down7", false);
        }
        //when bet made
        else if (GameScript.BetMade == true)
        {
            ButtonInteractable("MinusButton", false);
            ButtonInteractable("PlusButton", false);

            ButtonInteractable("Equals7", true);
            ButtonInteractable("Up7", true);
            ButtonInteractable("Down7", true);

        }
        //start variant
        else
        {
            ButtonInteractable("MinusButton", true);
            ButtonInteractable("PlusButton", true);

            ButtonInteractable("Equals7", false);
            ButtonInteractable("Up7", false);
            ButtonInteractable("Down7", false);
        }
    }

    private void ButtonInteractable(string name, bool type)
    {
        GameObject.Find(name).GetComponent<Button>().interactable = type;
    }
}
