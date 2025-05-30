using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Scene Index")]
    [SerializeField] private int SceneIndex = 0;

    [Header("Gameplay Buttons")]
    public Button buttonResume;
    public Button buttonPause;
    public Button buttonMenu;

    private void Start()
    {
        buttonMenu.onClick.AddListener(() => GameManager.Instance.ChangeScene(SceneIndex));
        buttonPause.onClick.AddListener(HandleButtonClick);
        buttonResume.onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        if (GameManager.Instance.isPaused)
        {
            GameManager.Instance.Resume();
            buttonPause.gameObject.SetActive(true);
            buttonResume.gameObject.SetActive(false);
        }
        else
        {
            GameManager.Instance.Pause();
            buttonPause.gameObject.SetActive(false);
            buttonResume.gameObject.SetActive(true);
        }
    }
}
