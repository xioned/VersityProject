using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PartDetailsManager : MonoBehaviour
{
    public UnityEvent ExtandPartEvent;

    public void ExtandPart()
    {
        ExtandPartEvent?.Invoke();
    }
}
