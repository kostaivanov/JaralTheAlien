using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class TogglesController : MonoBehaviour
{
    [SerializeField] internal List<Button> buttons;
    private ColorBlock colorBlack;
    private Text textButton;

    private void Start()
    {

        foreach (Button button in buttons)
        {
            if (button.name == "Slider")
            {
                button.GetComponent<ToggleColorController>().state = false;
            }
            else
            {
                button.GetComponent<ToggleColorController>().state = true;
            }

            colorBlack = button.colors;
            if (button.GetComponent<ToggleColorController>().state == false)
            {
                colorBlack.normalColor = Color.white;
                colorBlack.highlightedColor = Color.white;
                textButton = button.GetComponentInChildren<Text>();
                textButton.color = new Color(1f, 1f, 1f, 0.4f);
            }
        }
    }
}
