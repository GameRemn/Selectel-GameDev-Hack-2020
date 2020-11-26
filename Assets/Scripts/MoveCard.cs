using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MoveCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform baseRt;
    private RectTransform _selfRt;
    private Vector3 _dragStartPosition;
    private Vector3 _selfStartPosition;
    private Card _card;
    private void Start()
    {
        // _baseRt = GameObject.FindWithTag("base").GetComponent<RectTransform>(); // TODO может что-то не сработать
        _selfRt = GetComponent<RectTransform>();
        _selfStartPosition = transform.position;
        _card = GetComponent<Card>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragStartPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, transform.position.y, 0); // TODO смещение
        if (_dragStartPosition.x > transform.position.x) // Left
        {
            _card.СhangeTextLeft();
        }
        else // Right
        {
            _card.СhangeTextRight();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3[] corners = new Vector3[4];
        
        baseRt.GetWorldCorners(corners);

        Vector3 baseBottomLeft = corners[0];
        Vector3 baseTopRight = corners[2];
        
        _selfRt.GetWorldCorners(corners);
        Vector3 selfBottomLeft = corners[0];
        Vector3 selfTopRight = corners[2];
        
        // Debug.Log("Base left: " + baseBottomLeft);
        // Debug.Log("Self left: " + selfBottomLeft);
        if (_dragStartPosition.x > transform.position.x) // Left
        {
            if (selfTopRight.x > baseBottomLeft.x)
            {
                transform.position = _selfStartPosition; // TODO передалть на corutine
                _card.СhangeText();
            }
            else
            {
                _card.OnLeftEvent();
            }
        }
        else // Right
        {
            if (selfBottomLeft.x < baseTopRight.x)
            {
                transform.position = _selfStartPosition; // TODO передалть на corutine
                _card.СhangeText();
            }
            else
            {
                _card.OnRightEvent();
            }
        }
    }
}
