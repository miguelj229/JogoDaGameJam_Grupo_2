using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public Customer customerPrefab;
    public Transform[] seats;
    public Transform exitPoint;
    public Recipe[] recipes;

    private int currentSeat = 0;

    public float spawnInterval = 10f;
    public float spawnDelay = 2f;
    public int maxCustomers = 4;

    private readonly List<Customer> activeCustomers = new List<Customer>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        InvokeRepeating(nameof(TrySpawnCustomer), spawnDelay, spawnInterval);
    }

    void TrySpawnCustomer()
    {
        if (seats.Length == 0 || recipes.Length == 0)
            return;

        if (activeCustomers.Count >= Mathf.Min(maxCustomers, seats.Length))
            return;

        int seatIndex = FindAvailableSeat();
        if (seatIndex < 0)
            return;

        Recipe recipe = recipes[Random.Range(0, recipes.Length)];
        Customer customer = Instantiate(customerPrefab,
                                        seats[seatIndex].position,
                                        Quaternion.identity);
        customer.Initialize(recipe, exitPoint, this, seats[seatIndex]);
        activeCustomers.Add(customer);
    }

    int FindAvailableSeat()
    {
        for (int i = 0; i < seats.Length; i++)
        {
            bool seatTaken = false;
            foreach (Customer activeCustomer in activeCustomers)
            {
                if (activeCustomer != null && activeCustomer.AssignedSeat == seats[i])
                {
                    seatTaken = true;
                    break;
                }
            }

            if (!seatTaken)
                return i;
        }

        return -1;
    }

    public void OnCustomerLeft(Customer customer)
    {
        activeCustomers.Remove(customer);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
