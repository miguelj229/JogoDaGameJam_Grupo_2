using JetBrains.Annotations;
using UnityEngine;

public enum CustomerState
{
    Entering,
    Waiting,
    Leaving
}

public class Customer : MonoBehaviour
{
    public Recipe requestedRecipe;
    public OrderBubble orderBubble;
    public float waitTime = 60f;
    public float leaveSpeed = 3f;

    public Transform AssignedSeat { get; private set; }
    public Transform ExitPoint { get; private set; }
    public CustomerState state { get; private set; }

    private float currentTime;
    private CustomerController customerController;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        currentTime = waitTime;
        state = CustomerState.Waiting;
    }

    public void Initialize(Recipe recipe, Transform exitPoint, CustomerController controller, Transform assignedSeat)
    {
        requestedRecipe = recipe;
        ExitPoint = exitPoint;
        customerController = controller;
        AssignedSeat = assignedSeat;
        currentTime = waitTime;
        state = CustomerState.Waiting;

        if (orderBubble != null)
            orderBubble.SetRecipe(requestedRecipe);

        if (orderBubble != null)
            orderBubble.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (state != CustomerState.Waiting)
            return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            LeaveAngry();
        }
    }

    public void Serve(Recipe recipe)
    {
        if (state != CustomerState.Waiting)
            return;

        if (recipe == requestedRecipe)
        {
            Debug.Log("Pedido correto!");
            LeaveHappy();
        }
        else
        {
            LeaveAngry();
        }
    }

    void LeaveHappy()
    {
        state = CustomerState.Leaving;
        if (orderBubble != null)
            orderBubble.gameObject.SetActive(false);
    }

    void LeaveAngry()
    {
        state = CustomerState.Leaving;
        if (orderBubble != null)
            orderBubble.gameObject.SetActive(false);
    }

    private void LateUpdate()
    {
        if (state != CustomerState.Leaving || ExitPoint == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, ExitPoint.position, leaveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, ExitPoint.position) < 0.1f)
        {
            customerController?.OnCustomerLeft(this);
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        orderBubble = GetComponentInChildren<OrderBubble>();
    }
}
