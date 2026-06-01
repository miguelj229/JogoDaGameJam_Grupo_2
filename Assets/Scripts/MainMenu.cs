using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Botão JOGAR
    public void Jogar()
    {
        SceneManager.LoadScene(1);
    }

    // Botão VOLTAR AO MENU
    public void VoltarMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Botão SAIR
    public void Sair()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

        Debug.Log("Jogo fechado");
    }
}