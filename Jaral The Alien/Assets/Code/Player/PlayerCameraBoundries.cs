using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraBoundries : MonoBehaviour
{
    [SerializeField] private Camera MainCamera;
    [SerializeField] private GameObject inGameScreen;
    private Vector2 screenBounds;

    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (inGameScreen.activeSelf == true)
        {
            Vector3 viewPosition = transform.position;
            viewPosition.x = Mathf.Clamp(viewPosition.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
            viewPosition.y = Mathf.Clamp(viewPosition.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
            transform.position = viewPosition;
        }
    }
}
