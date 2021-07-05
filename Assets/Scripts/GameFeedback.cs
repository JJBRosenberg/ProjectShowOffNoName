using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class GameFeedback : MonoBehaviour
{
    public static GameFeedback Instance { get; private set; }

    private Text text;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            text = GetComponent<Text>();
            text.text = "";
        }
        //destroys any copies
        else
        {
            Destroy(gameObject);
        }
    }
    //sets text clears after 5 seconds
    public void SetText(string info)
    {
        text.text = info;
        StopAllCoroutines();
        StartCoroutine(ClearText());
    }


    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(5);
        text.text = "";
    }

}
