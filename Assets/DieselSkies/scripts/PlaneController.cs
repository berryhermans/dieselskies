using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : InputBroadcaster
{
    public InputBroadcaster PlayerInput;
    [Range(1, 4)]
    public int PlaneNumber; // is it the first, second, third or fourth plane? TODO: come up with a decent var name.

    private bool _isSelected = false;

    #region UNITY_EVENTS
    private void OnEnable()
    {
        PlayerInput.Vector2Broadcasted += OnVector2BroadcastedHandler;
        PlayerInput.RewiredButtonEventBroadcasted += OnRewiredButtonEventBroadcastedHandler;
    }

    private void OnDisable()
    {
        PlayerInput.Vector2Broadcasted -= OnVector2BroadcastedHandler;
        PlayerInput.RewiredButtonEventBroadcasted -= OnRewiredButtonEventBroadcastedHandler;
    }
    #endregion

    #region PRIVATE
    private void OnRewiredButtonEventBroadcastedHandler(RewiredButtonEventModel buttonEvent)
    {
        int selectedPlane;
        switch (buttonEvent.ActionName)
        {
            case RewiredConstants.ACTION_SELECT_PLANE_FIRST:
                selectedPlane = 1;
                break;
            case RewiredConstants.ACTION_SELECT_PLANE_SECOND:
                selectedPlane = 2;
                break;
            case RewiredConstants.ACTION_SELECT_PLANE_THIRD:
                selectedPlane = 3;
                break;
            case RewiredConstants.ACTION_SELECT_PLANE_FOURTH:
                selectedPlane = 4;
                break;
            default:
                selectedPlane = -1;
                break;
        }

        if (selectedPlane.Equals(PlaneNumber))
        {
            switch (buttonEvent.EventType)
            {
                case ButtonEvent.ButtonDown:
                    _isSelected = true;
                    break;
                case ButtonEvent.ButtonUp:
                    _isSelected = false;
                    break;
                default:
                    break;
            }
        }
    }

    private void OnVector2BroadcastedHandler(Vector2 vector2)
    {
        if (_isSelected)
        {
            BroadcastVector2(vector2);
        }
    }
    #endregion
}
