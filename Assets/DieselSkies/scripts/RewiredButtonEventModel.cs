using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewiredButtonEventModel : MonoBehaviour
{
    public string ActionName;
    public ButtonEvent EventType;    
}

public enum ButtonEvent
{
    ButtonDown,
    ButtonHeld,
    ButtonUp,
}