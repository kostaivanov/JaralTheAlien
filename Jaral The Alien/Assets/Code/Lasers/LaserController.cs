using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] float laserSpeed;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * laserSpeed;
    }

    private void OnEnable()
    {
        if (rigidBody != null)
        {
            rigidBody.velocity = Vector2.right * laserSpeed;
        }
        Invoke("Disable", 1f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
