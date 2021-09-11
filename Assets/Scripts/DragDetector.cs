using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDetector : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    List<Vector2> dragPosition = new List<Vector2>();
    int count = 0;

    private GameManager _gameManager;


    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragPosition.Add(eventData.position);
        count++;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_gameManager.obstaclesActive)
        {
            dragPosition.Add(eventData.position);
            count++;

            float sideMovement = dragPosition[count - 1].x - dragPosition[count - 2].x;
            FindObjectOfType<CharacterController>().moveSide(sideMovement);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragPosition.Clear();
        count = 0;
    }
}
