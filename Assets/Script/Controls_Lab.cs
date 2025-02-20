using System.Collections;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public GameObject targetObject; // Object to rotate
    public float rotationAngle = 30f; // Rotation angle per key press
    public float rotationSpeed = 2f; // Speed of rotation (higher = faster)

    private bool isRotating = false; // Prevents multiple rotations at once

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isRotating)
        {
            StartCoroutine(RotateSmooth(rotationAngle));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isRotating)
        {
            StartCoroutine(RotateSmooth(-rotationAngle));
        }
    }

    IEnumerator RotateSmooth(float angle)
    {
        isRotating = true;

        Quaternion startRotation = targetObject.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(
            targetObject.transform.eulerAngles.x, 
            targetObject.transform.eulerAngles.y + angle, 
            targetObject.transform.eulerAngles.z
        );

        float timeElapsed = 0f;

        while (timeElapsed < 1f)
        {
            targetObject.transform.rotation = Quaternion.Slerp(startRotation, endRotation, timeElapsed);
            timeElapsed += Time.deltaTime * rotationSpeed;
            yield return null;
        }

        targetObject.transform.rotation = endRotation;
        isRotating = false;
    }
}