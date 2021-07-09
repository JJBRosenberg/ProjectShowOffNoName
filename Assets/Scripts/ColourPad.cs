using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourPad : MonoBehaviour
{
    [SerializeField] Text codeText;
    [SerializeField] string passcode;
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
        if (codeTextValue.Length >= 5)
        {
            codeTextValue = "";
        }

    }
    private void ifCorrect()
    {
        if (codeTextValue == passcode)
        {
            KeyPanelCode.isKeyPanelopen = true;
        }
    }
}
