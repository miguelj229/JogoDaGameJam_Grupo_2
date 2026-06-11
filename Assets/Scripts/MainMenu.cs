using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject painelPausa;
    public GameObject botaoPausa;

    private bool pausado = false;

    void Start()
    {
        if (painelPausa != null)
            painelPausa.SetActive(false);

        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
            {
                ContinuarJogo();
            }
            else
            {
                AbrirMenuPausa();
            }
        }
    }

    // MENU PRINCIPAL

    public void Jogar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void Sair()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

        Debug.Log("Jogo fechado");
    }

    // MENU DE PAUSA

    public void AbrirMenuPausa()
    {
        if (painelPausa != null)
            painelPausa.SetActive(true);

        if (botaoPausa != null)
            botaoPausa.SetActive(false);

        Time.timeScale = 0f;
        pausado = true;
    }

    public void ContinuarJogo()
    {
        if (painelPausa != null)
            painelPausa.SetActive(false);

        if (botaoPausa != null)
            botaoPausa.SetActive(true);

        Time.timeScale = 1f;
        pausado = false;
    }

    public void VoltarMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}