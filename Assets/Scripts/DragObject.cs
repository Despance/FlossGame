using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler
{
    private Vector3 startPos;
    private Vector3 RectTransformStart;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Canvas canvas;

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        transform.position = startPos;
        rectTransform.anchoredPosition = RectTransformStart;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    // Start is called before the first frame update

    void Awake()

    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        startPos = transform.position;
        RectTransformStart = rectTransform.anchoredPosition;


    }


}
