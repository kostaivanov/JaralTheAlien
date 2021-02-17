using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InstructionsHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private CanvasManager canvasManager;

    public void OnPointerDown(PointerEventData eventData)
    {
        canvasManager.SwitchCanvas(CanvasType.Instructions);
    }
}
