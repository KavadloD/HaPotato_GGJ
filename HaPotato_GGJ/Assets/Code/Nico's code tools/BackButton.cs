using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public GameObject uiElement;
    public Button backButton;

    void Start()
    {
        backButton.onClick.AddListener(TurnOffUIElement);
    }

    void TurnOffUIElement()
    {
        uiElement.SetActive(false);
    }
}