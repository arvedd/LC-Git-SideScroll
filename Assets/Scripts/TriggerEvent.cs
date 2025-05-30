using UnityEngine;
using UnityEngine.Events;

public enum TypeTag
{
    Player,
    Checkpoint,
    Trigger
}

public class TriggerEvent : MonoBehaviour
{
    public TypeTag targetTag;
    public UnityEvent<GameObject> OnTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == targetTag.ToString())
        {
            Debug.Log(gameObject.tag + " kena! " + collision.gameObject.tag);
            OnTrigger?.Invoke(collision.gameObject);
            CharacterEvents.characterCheckpoint.Invoke(gameObject, "Checkpoint");
        }
    }
}
