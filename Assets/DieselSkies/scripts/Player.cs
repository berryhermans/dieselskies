using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using TMPro;

public class Player : InputBroadcaster
{
    public int PlayerId = 0;

    private Rewired.Player _playerInput;

    #region RewiredInputs
    bool _selectFirstDown;
    bool _selectSecondDown;
    bool _selectThirdDown;
    bool _selectFourthDown;

    bool _selectFirstUp;
    bool _selectSecondUp;
    bool _selectThirdUp;
    bool _selectFourthUp;
    #endregion

    private void Awake()
    {
        _playerInput = ReInput.players.GetPlayer(PlayerId);
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        Vector2 axis = new Vector2(_playerInput.GetAxis(RewiredConstants.ACTION_MOVE_HORIZONTAL), _playerInput.GetAxis(RewiredConstants.ACTION_MOVE_VERTICAL));

        // get button down
        _selectFirstDown = _playerInput.GetButtonDown(RewiredConstants.ACTION_SELECT_PLANE_FIRST);
        _selectSecondDown = _playerInput.GetButtonDown(RewiredConstants.ACTION_SELECT_PLANE_SECOND);
        _selectThirdDown = _playerInput.GetButtonDown(RewiredConstants.ACTION_SELECT_PLANE_THIRD);
        _selectFourthDown = _playerInput.GetButtonDown(RewiredConstants.ACTION_SELECT_PLANE_FOURTH);

        // get button up
        _selectFirstUp = _playerInput.GetButtonUp(RewiredConstants.ACTION_SELECT_PLANE_FIRST);
        _selectSecondUp = _playerInput.GetButtonUp(RewiredConstants.ACTION_SELECT_PLANE_SECOND);
        _selectThirdUp = _playerInput.GetButtonUp(RewiredConstants.ACTION_SELECT_PLANE_THIRD);
        _selectFourthUp = _playerInput.GetButtonUp(RewiredConstants.ACTION_SELECT_PLANE_FOURTH);

        // broadcast button down
        if (_selectFirstDown)
        {
            BroadcastRewiredButtonEvent(new RewiredButtonEventModel {
                ActionName = RewiredConstants.ACTION_SELECT_PLANE_FIRST,
                EventType = ButtonEvent.ButtonDown
            });
        }
        if (_selectSecondDown)
        {
            BroadcastRewiredButtonEvent(new RewiredButtonEventModel {
                ActionName = RewiredConstants.ACTION_SELECT_PLANE_SECOND,
                EventType = ButtonEvent.ButtonDown
            });
        }
        if (_selectThirdDown)
        {
            BroadcastRewiredButtonEvent(new RewiredButtonEventModel {
                ActionName = RewiredConstants.ACTION_SELECT_PLANE_THIRD,
                EventType = ButtonEvent.ButtonDown
            });
        }
        if (_selectFourthDown)
        {
            BroadcastRewiredButtonEvent(new RewiredButtonEventModel {
                ActionName = RewiredConstants.ACTION_SELECT_PLANE_FOURTH,
                EventType = ButtonEvent.ButtonDown
            });
        }

        // broadcast button up
        if (_selectFirstUp)
        {
            BroadcastRewiredButtonEvent(new RewiredButtonEventModel {
                ActionName = RewiredConstants.ACTION_SELECT_PLANE_FIRST,
                EventType = ButtonEvent.ButtonUp
            });
        }
        if (_selectSecondUp)
        {
            BroadcastRewiredButtonEvent(new RewiredButtonEventModel {
                ActionName = RewiredConstants.ACTION_SELECT_PLANE_SECOND,
                EventType = ButtonEvent.ButtonUp
            });
        }
        if (_selectThirdUp)
        {
            BroadcastRewiredButtonEvent(new RewiredButtonEventModel {
                ActionName = RewiredConstants.ACTION_SELECT_PLANE_THIRD,
                EventType = ButtonEvent.ButtonUp
            });
        }
        if (_selectFourthUp)
        {
            BroadcastRewiredButtonEvent(new RewiredButtonEventModel {
                ActionName = RewiredConstants.ACTION_SELECT_PLANE_FOURTH,
                EventType = ButtonEvent.ButtonUp
            });
        }
    }
}
