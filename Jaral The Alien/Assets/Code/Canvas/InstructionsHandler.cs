using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InstructionsHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private CanvasManager canvasManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        canvasManager.SwitchCanvas(CanvasType.Instructions);
    }
}
