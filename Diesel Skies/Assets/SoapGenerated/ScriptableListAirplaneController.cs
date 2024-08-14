using UnityEngine;
using Obvious.Soap;

[CreateAssetMenu(fileName = "scriptable_list_" + nameof(AirplaneController), menuName = "Soap/ScriptableLists/"+ nameof(AirplaneController))]
public class ScriptableListAirplaneController : ScriptableList<AirplaneController>
{
    
}
