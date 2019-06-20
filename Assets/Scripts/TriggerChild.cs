using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChild : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
      transform.parent.GetComponent<Brick>().onChildTrigger(other);
    }
}
