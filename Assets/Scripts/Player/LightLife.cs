using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LightLife : MonoBehaviour
{
    private int seconds;
    private int minutes;

    public TMP_Text text;


    //https://www.bing.com/videos/search?q=coroutine+timer+unity&qpvt=coroutine+timer+unity&view=detail&mid=3FC186B643C68BA5A6063FC186B643C68BA5A606&&FORM=VRDGAR&ru=%2Fvideos%2Fsearch%3Fq%3Dcoroutine%2Btimer%2Bunity%26qpvt%3Dcoroutine%2Btimer%2Bunity%26FORM%3DVDRE
    //pour timer

    public void Start()
    {
        StartTime();

    }




    public void Reset()
    {
        seconds = 0;
        minutes = 0;

        text.text = "0.0";
    }

    public void StartTime()
    {
        StartCoroutine(Timer());
    }

    public void StopTime()
    {
        StopAllCoroutines();
    }

    private IEnumerator Timer()
    {

        while (minutes < 2)
        {
            yield return new WaitForSeconds(1);
            seconds++;

            if (seconds == 60)
            {
                minutes++;
                seconds = 0;
            }

            text.text = minutes.ToString() + ":" + seconds.ToString();
        }

    }









}
