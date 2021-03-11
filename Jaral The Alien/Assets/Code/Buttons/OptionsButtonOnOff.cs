using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsButtonOnOff : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject optionsPanel;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (optionsPanel.activeSelf == false)
        {
            optionsPanel.SetActive(true);
        }
        else
        {
            optionsPanel.SetActive(false);
        }
    }


}
