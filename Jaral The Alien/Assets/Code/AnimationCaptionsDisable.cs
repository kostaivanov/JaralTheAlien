using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCaptionsDisable : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    public void DeactivateObject()
    {
        this.gameObject.SetActive(false);
    }
}
