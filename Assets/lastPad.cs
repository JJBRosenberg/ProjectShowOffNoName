using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lastPad : MonoBehaviour
{
    [SerializeField] Text codeText;
    [SerializeField] string passcode;
    otherMetalBox otherMetalBox;
    string codeTextValue = "";

    private void Update()
    {
        codeText.text = codeTextValue;
        ifCorrect();
        resetCode();
    }
    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
    private void resetCode()
    {
        if (codeTextValue.Length >= 4)
        {
            codeTextValue = "";
        }

    }
    private void ifCorrect()
    {
        if (codeTextValue == passcode)
        {
            otherMetalBox.ifCorrect();
        }
    }
}
