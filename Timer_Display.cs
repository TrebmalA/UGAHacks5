using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Display : MonoBehaviour
{
    int timeLeft;
    string seconds;
    string minutes;
    public Text timerText;
    public GameObject btnMngr;

    public void startTimer()
    {
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        timeLeft = 60;
        while (true)
        {
            timeLeft -= 1;
            if (timeLeft <= 0)
            {
                //TO-DO
                //IMPLEMENT GAME OVER
                timerText.text = "0";
                btnMngr.GetComponent<Button_Manager>().EndWhackAMole();
            }
            else
            {
                seconds = timeLeft >= 60 ? ""+timeLeft % 60 : timeLeft>=10 ? ""+timeLeft : "0"+timeLeft;
                minutes = ""+timeLeft / 60;
                timerText.text = "" + minutes + ":" + seconds;
                Debug.Log(""+minutes+":"+seconds);
                Debug.Log(timeLeft);
            }
            yield return new WaitForSeconds(1.0f);

        }
    }
}
