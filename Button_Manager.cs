using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Manager : MonoBehaviour
{
    public Material highlightedButton;
    public Material buttonMat;
    public List<GameObject> buttonList = new List<GameObject>();
    int num = -1;
    public Text scoreText;
    public int score = 0;
    private bool pressed = false;
    Coroutine game = null;
    public GameObject timerDisplay;
    private GameObject button;

   /*public void Start()
    {
        StartCoroutine(whackAMole());
    }*/

    public void startWhackAMole()
    {
        score = 0;
        scoreText.text = "0";
        timerDisplay.GetComponent<Timer_Display>().startTimer();
        game = StartCoroutine(whackAMole());
    }

    IEnumerator whackAMole()
    {
        //Set a random number to change a random button's color
        num = Random.Range(0, 9);
        //change the random button to the highlighted color
        buttonList[num].GetComponentInChildren<MeshRenderer>().material = highlightedButton;
        //set timer to 0
        float resetTimer = 0.0f;
        while (true)
        {

            //If timer is greater than 1, a full second has passed.
            //When this happens we get a new random button and change the old
            //button back to the normal material
            //----------------------------------
            //If timer is less than 1 we incrememnt timer or we reset if
            //the active button is pushed.
            //a tag defines the active button
            if (resetTimer >= 1.0f)
            {
                //Change Button back
                //new random #
                //set new button to highlighted material
                //change tag so we can press it
                //reset timer to 0
                buttonList[num].GetComponentInChildren<MeshRenderer>().material = buttonMat;
                num = Random.Range(0, 9);
                buttonList[num].GetComponentInChildren<MeshRenderer>().material = highlightedButton;
                buttonList[num].transform.GetChild(0).tag = "Active_Button";
                resetTimer = 0.0f;
                yield return null;
            }
            else
            {
                //Increment timer
                //if we press an active button we reset time
                resetTimer += Time.deltaTime;
                   if (buttonList[num].transform.GetChild(0).tag == "Button")
                    {
                        resetTimer = 1.0f;
                        yield return null;
                    }
                yield return null;
            }
        }
    }

    public void incrementScore(GameObject btn)
    {
        if (btn.tag == "Active_Button")
        {
            score++;
            scoreText.text = "" + score;
            btn.tag = "Button";
        }
    }
    public void EndWhackAMole()
    {
        StopCoroutine(game);
    }
}
