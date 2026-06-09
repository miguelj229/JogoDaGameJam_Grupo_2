using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject painelPausa;

    private bool pausado = false;

    void Start()
    {
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

    public void AbrirMenuPausa()
    {
        painelPausa.SetActive(true);
        Time.timeScale = 0f;
        pausado = true;
    }

    public void ContinuarJogo()
    {
        painelPausa.SetActive(false);
        Time.timeScale = 1f;
        pausado = false;
    }

    public void VoltarMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}