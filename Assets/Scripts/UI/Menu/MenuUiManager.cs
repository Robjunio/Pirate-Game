using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUiManager : MonoBehaviour
{
    private string GameplayScene = "Gameplay";
    
    public void StartGame()
    {
        SceneManager.LoadScene(GameplayScene);
    }
}
