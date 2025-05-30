using UnityEngine;
using UnityEngine.Events;

public class CharacterEvents
{
    public static UnityAction<GameObject, int> characterDamage;
    public static UnityAction<GameObject, int> characterHealed;
    public static UnityAction<GameObject, string> characterCheckpoint;
}
