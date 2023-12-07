using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 15f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 4f;

    [SerializeField] float pitchFactor = -2f;
    [SerializeField] float yawFactor = -0f;
    [SerializeField] float rollFactor = -0f;

    private void OnEnable() {
      movement.Enable();
    }

    private void OnDisable() {
      movement.Disable();
    }

    void Update() {
      ProcessTranslation();
      ProcessRotation();
    }

    private void ProcessTranslation() {
            float xThrow = movement.ReadValue<Vector2>().x;
      float yThrow = movement.ReadValue<Vector2>().y;

      float xOffset = xThrow * Time.deltaTime * controlSpeed;
      float yOffset = yThrow * Time.deltaTime * controlSpeed;

      float rawXPos = transform.localPosition.x + xOffset;
      float rawYPos = transform.localPosition.y + yOffset;

      float newXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
      float newYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

      // Use local position to move player ship
      transform.localPosition = new(newXPos, newYPos, 0);
    }

    private void ProcessRotation() {
      float pitch = transform.localPosition.y * pitchFactor;
      float yaw = 0f;
      float roll = 0f;
      transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
