using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class ToggleColorController : MonoBehaviour
{
    private Button button;
    //private Text textButton;

    internal bool state;
    private TogglesController toggleController;
    private ToggleColorController buttons;
    private ToggleColorController slider;
    [SerializeField] private GameObject parentButtons;
    private GameObject theOtherChild;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged()
    {
        if (this.state == false)
        {
            int index = this.transform.GetSiblingIndex();
            if (index == 0)
            {
                theOtherChild = parentButtons.transform.GetChild(1).gameObject;
                theOtherChild.GetComponent<ToggleColorController>().state = false;
                SelectColorMode(theOtherChild, false);
                state = true;
            }
            else if (index == 1)
            {
                theOtherChild = parentButtons.transform.GetChild(0).gameObject;
                theOtherChild.GetComponent<ToggleColorController>().state = false;
                SelectColorMode(theOtherChild, false);
                state = true;
            }
        }


        SelectColorMode(this.gameObject, state);
    }

    private void SelectColorMode(GameObject obj, bool state)
    {
        Button currentButton = obj.GetComponent<Button>();
        ColorBlock colorBlack = currentButton.colors;
        Text textButton = obj.GetComponentInChildren<Text>();

        if (state == true)
        {
            colorBlack.normalColor = new Color(1f, 1f, 1f);
            colorBlack.highlightedColor = new Color(0.9607f, 0.9607f, 0.9607f);
            colorBlack.pressedColor = new Color(0.7843f, 0.7843f, 0.7843f);
            textButton.color = new Color(0.2274f, 0.8862f, 0f, 1f);
        }
        else
        {
            colorBlack.normalColor = Color.white;
            colorBlack.highlightedColor = Color.white;
            textButton.color = new Color(1f, 1f, 1f, 0.4f);

        }
        button.colors = colorBlack;
        EventSystem.current.SetSelectedGameObject(null);
    }
}
