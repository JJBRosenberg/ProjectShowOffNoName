using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpriteSwapper : MonoBehaviour
{
    public Sprite sprite1; // Drag your first sprite here
    public Sprite sprite2; // Drag your second sprite here
    private bool gotClicked;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void GetsClicked()
    {
        Debug.Log("yes");
        gotClicked = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(gotClicked)
        {
            ChangeTheDarnSprite();
        }
    }

    public void ChangeTheDarnSprite()
    {

        spriteRenderer.sprite = sprite2;
    }
}
