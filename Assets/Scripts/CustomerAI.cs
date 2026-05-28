using UnityEngine;

public class CustomerAI : MonoBehaviour
{
    public enum CustomerState
    {
        Entering,
        WaitingInLine,
        GoingToTable,
        WaitingFood,
        Eating,
        Leaving,
        Angry
    }

    public CustomerState currentState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = CustomerState.Entering;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case CustomerState.Entering:
                HandleEntering();
                break;

            case CustomerState.WaitingFood:
                HandleWaitingFood();
                break;

            case CustomerState.Eating:
                HandleEating();
                break;

            case CustomerState.Leaving:
                HandleLeaving();
                break;
        }
    }

    void HandleEntering()
    {
        // andar até fila
    }

    void HandleWaitingFood()
    {
        // esperar pedido
    }

    void HandleEating()
    {
        // temporizador
    }

    void HandleLeaving()
    {
        // sair do mapa
    }

    
}
