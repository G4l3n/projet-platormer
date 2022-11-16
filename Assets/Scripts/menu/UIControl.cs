using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public TMP_Text text = null;
    public Image image = null;
    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public int AppeasementThreshold = 30;
    int numberOfClicks = 0;
    public void ChangeText()
    {
        numberOfClicks++;
        image.color = Color.Lerp(color1, color2, ((float) numberOfClicks) / ((float) AppeasementThreshold));
        text.text = $"ButtonClicked : {numberOfClicks}";
    }
    public void ValueChanged(float value)
    {
        Debug.Log($"value changed : {value}");
    }
}
