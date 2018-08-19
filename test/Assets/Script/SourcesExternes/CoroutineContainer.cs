using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineContainer : MonoBehaviour
{


    /// <summary>
    /// Raises the disable event.
    /// </summary>
    void OnDisable()
    {
        StopAllCoroutines();
    }
}
