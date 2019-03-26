using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Gamepad : MonoBehaviour
{
    public int PlayerId = 0;

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

        Debug.Log(string.Format("({0} ; {1}) | first: {2} | second: {3} | third: {4} | foruth: {5}", 
            axis.x.ToString("0.00"), 
            axis.y.ToString("0.00"), 
            SelectFirst, 
            SelectSecond, 
            SelectThird, 
            SelectFourth));
    }
}
