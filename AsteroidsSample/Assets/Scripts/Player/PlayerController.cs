using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovment))]
public class PlayerController : MonoBehaviour, IDestroyable
{
    private PlayerMovment movement;

    private void Awake()
    {
        movement = GetComponent<PlayerMovment>();
        Debug.Assert(movement, $"Ref to {typeof(PlayerMovment)} script was not found");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement.InputMovement();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
