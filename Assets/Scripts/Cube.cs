using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum side
{
    right,
    left
}

public class Cube : MonoBehaviour
{
    public side mySide;

    private void OnTriggerEnter(Collider other)
    {
        transform.parent.GetComponent<Gate>().Upgrade(mySide);
    }
}
