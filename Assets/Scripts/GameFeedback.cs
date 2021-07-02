using UnityEngine;
using UnityEngine.UI;
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
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetText(string info)
    {
        text.text = info;
    }
}
