using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    float FireRate { get; }
    public void Fire(List<GameObject> validTargets);
}