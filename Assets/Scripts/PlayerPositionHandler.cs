using UnityEngine;

public class PlayerPositionHandler : MonoBehaviour
{
    [SerializeField] Vector2 playerCurrentPosition;
    [SerializeField] Vector2 currentCheckpointPosition;
    public TransformData playerPositionData;
    private TriggerEvent playerTriggerEvent;
    private Transform player;


    void Start()
    {
        playerTriggerEvent = GetComponent<TriggerEvent>();
    }

    public void OnCheckpoint(GameObject col)
    {
        Vector2 newCheckpointPosition = col.transform.position;
        currentCheckpointPosition = newCheckpointPosition;
        SavePosition(currentCheckpointPosition);
    }

    // public void CheckpointWallActive(GameObject wall)
    // {
    //     wall.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    // }

    public void LoadPosition()
    {
        playerCurrentPosition = playerPositionData.position;

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
        }

        if (player != null)
        {
            player.position = playerCurrentPosition;
            Debug.Log("Player dipindahkan ke checkpoint: " + playerCurrentPosition);
        }
        else
        {
            Debug.LogError("Player tidak ditemukan saat respawn!");
        }
    }

    private void ChangePlayerPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }

    private void SavePosition(Vector2 newPosition)
    {
        playerPositionData.position = newPosition;
    }

}
