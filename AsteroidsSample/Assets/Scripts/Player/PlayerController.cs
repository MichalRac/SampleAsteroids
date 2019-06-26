using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovment))]
public class PlayerController : MonoBehaviour, IDestroyable
{
    [SerializeField] private Particle particleOnDestroy;
    private PlayerMovment movement;

    private void Awake()
    {
        movement = GetComponent<PlayerMovment>();
        Debug.Assert(movement, $"Ref to {typeof(PlayerMovment)} script was not found");
    }

    private void OnEnable()
    {
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement.InputMovement();
    }

    public void DestroyGameObject()
    {
        gameObject.SetActive(false);
        GameManager.Instance.OnLostLife();
        Instantiate(particleOnDestroy, transform.position, transform.rotation);
    }
}
