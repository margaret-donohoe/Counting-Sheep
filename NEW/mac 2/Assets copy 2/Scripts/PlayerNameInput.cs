using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNameInput : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public Button submitButton;

    private string PlayerName;

    void Start()
    {
        // Ensure the button is connected and add a listener to the button's onClick event
        if (submitButton != null)
        {
            submitButton.onClick.AddListener(OnSubmitNames);
        }
    }

    private void OnSubmitNames()
    {
        // Retrieve player names from the TMP_InputField components
        PlayerName = playerNameInput.text;

        // Debug log to confirm the names (replace this with your actual game logic)
        Debug.Log($"Player Name: {PlayerName}");

        // Example: Use these names for further game setup, e.g., load the game scene, etc.
    }
}
