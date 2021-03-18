using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    public bool runningRoutine;

    public void Move(float ammount)
    {
        if (!runningRoutine)
        {
            Vector3 destination = transform.position + transform.forward * ammount;
            //print(transform.position + " " + destination);
            StartCoroutine(MoveBehaviour(destination));
        }
    }

    public void Rotate(float ammount)
    {
        if (!runningRoutine)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(Quaternion.AngleAxis(ammount, transform.up) * transform.forward);
            StartCoroutine(RotatteBehavoir(desiredRotation));
        }
    }

    IEnumerator MoveBehaviour(Vector3 target)
    {
        runningRoutine = true;
        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }
        runningRoutine = false;
    }

    IEnumerator RotatteBehavoir(Quaternion desiredRotation)
    {
        runningRoutine = true;
        while (transform.rotation.eulerAngles != desiredRotation.eulerAngles)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }
        runningRoutine = false;
    }
}
