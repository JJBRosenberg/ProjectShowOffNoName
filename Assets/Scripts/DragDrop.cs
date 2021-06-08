using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour , IPointerDownHandler , IEndDragHandler, IBeginDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    //when the player first clicks
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Start drag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }
    //when the player drags the object
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("dragging");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    //When the player stops dragging
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    //when the player lets go
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

}
