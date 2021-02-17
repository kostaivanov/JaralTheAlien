using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeObjectWhenDamaged : MonoBehaviour
{
    [Header("Info")]
    private Vector3 startPosition;
    private float timer;
    private Vector3 randomPosition;

    [Header("Settings")]
    [Range(0f, 2f)]
    public float time = 0.2f;
    [Range(0f, 2f)]
    public float distance = 0.1f;
    [Range(0f, 0.1f)]
    public float delayBetweenShakes = 0f;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void OnValidate()
    {
        if (delayBetweenShakes > time)
        {
            delayBetweenShakes = time;
        }
    }

    public void BeginShakingObject()
    {
        StopAllCoroutines();
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        timer = 0f;

        while (timer < time)
        {
            timer += Time.deltaTime;

            randomPosition = transform.position + (Random.insideUnitSphere * distance);

            transform.position = randomPosition;

            if (delayBetweenShakes > 0f)
            {
                yield return new WaitForSeconds(delayBetweenShakes);
            }
            else
            {
                yield return null;
            }
        }
    }
}
