using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnClickMainMenu()
    {
        Contexts contexts = Contexts.sharedInstance;
        contexts.game.CreateEntity().isSetMainMenu = true;
    }
    public void OnClickRestart()
    {
        Contexts contexts = Contexts.sharedInstance;
        contexts.game.CreateEntity().isRestart = true;
    }
}
