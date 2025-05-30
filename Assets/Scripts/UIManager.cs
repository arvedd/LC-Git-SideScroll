using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public GameObject healthTextPrefab;
    public GameObject CheckpointTextPrefab;
    public Canvas gameCanvas;

    private void Awake()
    {
        gameCanvas = FindAnyObjectByType<Canvas>();

    }

    private void OnEnable()
    {
        CharacterEvents.characterDamage += CharacterTookDamage;
        CharacterEvents.characterHealed += CharacterHealed;
        CharacterEvents.characterCheckpoint += CharacterCheckpoint;
    }

    private void OnDisable()
    {
        CharacterEvents.characterDamage -= CharacterTookDamage;
        CharacterEvents.characterHealed -= CharacterHealed;
    }

    public void CharacterTookDamage(GameObject character, int damageReceived)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);

        TMP_Text tmpText = Instantiate(damageTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform)
                            .GetComponent<TMP_Text>();

        tmpText.text = damageReceived.ToString();
    }

    public void CharacterHealed(GameObject character, int healthRestored)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);

        TMP_Text tmpText = Instantiate(healthTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform)
                            .GetComponent<TMP_Text>();

        tmpText.text = healthRestored.ToString();
    }

    private void CharacterCheckpoint(GameObject character, string checkpointText)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);

        TMP_Text tmpText = Instantiate(CheckpointTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform)
                            .GetComponent<TMP_Text>();

        tmpText.text = checkpointText;
    }
}
