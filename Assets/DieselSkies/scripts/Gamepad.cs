using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using TMPro;

public class Gamepad : MonoBehaviour
{
    public int PlayerId = 0;

    [Header("Debugging")]
    public bool LogInput;
    public TextMeshProUGUI Text;

    private Player _player;

    private void Awake()
    {
        _player = ReInput.players.GetPlayer(PlayerId);
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        Vector2 axis = new Vector2(_player.GetAxis("Move Horizontal"), _player.GetAxis("Move Vertical"));
        bool SelectFirst = _player.GetButton("Select First Plane");
        bool SelectSecond = _player.GetButton("Select Second Plane");
        bool SelectThird = _player.GetButton("Select Third Plane");
        bool SelectFourth = _player.GetButton("Select Fourth Plane");

        if (LogInput)
        {
            string logText = string.Format("({0} ; {1}) | first: {2} | second: {3} | third: {4} | fourth: {5}",
                axis.x.ToString("0.00"),
                axis.y.ToString("0.00"),
                SelectFirst,
                SelectSecond,
                SelectThird,
                SelectFourth);
            if (Text != null)
            {
                Text.text = logText;
            }
            else
            {
                Debug.Log(logText);
            }
        }
    }
}
