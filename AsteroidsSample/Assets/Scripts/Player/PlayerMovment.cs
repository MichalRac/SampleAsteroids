using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] protected float _movementSpeed;
    [SerializeField] protected float _rotationSpeed;

    private void Awake()
    {
        ForwardingObjectsBehaviour.basePlayerMovementSpeed = _movementSpeed;
    }

    private void Start()
    {
        GetSettingsData();
    }

    public void GetSettingsData()
    {
        _movementSpeed = DataSetupManager.Instance.InitData.playerBaseSpeed;
        _rotationSpeed = DataSetupManager.Instance.InitData.playerRotation;
    }

    public void InputMovement()
    {
        float movementValue = Input.GetAxis("Vertical");
        float rotationValue = Input.GetAxis("Horizontal");

        this.transform.Translate(new Vector3(0.0f, 0.0f, movementValue * _movementSpeed * Time.deltaTime));
        this.transform.Rotate(new Vector3(0.0f, rotationValue * _rotationSpeed * Time.deltaTime, 0.0f));
    }
}
