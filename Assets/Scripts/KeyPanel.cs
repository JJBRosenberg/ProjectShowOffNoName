using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPanel : MonoBehaviour
{
    [SerializeField] Text codeText;
    [SerializeField] string input;
    string codeTextValue = "";

    private void Update()
    {
        codeText.text = codeTextValue;

        if(codeTextValue == input)
        {
            KeyPanelCode.isKeyPanelopen = true;
        }

        if (codeTextValue.Length >= 4)
        {
            codeTextValue = "";
        }

    }

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
}
