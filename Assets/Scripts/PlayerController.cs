using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using System.ComponentModel;

public class PlayerController : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] float speed = 3f;
    [SerializeField] float dashSpeed;
    float speedAtual;
    [SerializeField] float dashCooldown;
    bool inDash;
    [SerializeField] Color highlightColor;

    List<GameObject> collidingWithList = new List<GameObject>();
    GameObject collidingWith;
    Transform item;

    private void Start()
    {
        speedAtual = speed;


    }

  void Update()
    {
        Move();
        Interact();
    }

  void Interact()
    {
        if (this.collidingWith == null) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (this.collidingWith.tag)
            {
                case "Container":
                    ContainerController container = this.collidingWith.GetComponent<ContainerController>();

                    if (this.item != null && !container.HaveItem())
                    {
                        this.item.position = container.transform.position;
                        this.item.parent = container.transform;
                        container.SetItem(this.item);
                        this.item = null;
                        return;
                    }

                    if (this.item == null && container.HaveItem())
                    {
                        this.item = container.GetItem();
                        this.item.position = this.transform.position;
                        this.item.parent = this.transform;
                        return;
                    }

                    break;
            }
        }
    }

  void Move()
    {
        Vector2 dir = Vector2.zero;
        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");
        dir.Normalize();

        if (Input.GetKeyDown(KeyCode.Q) && dir != Vector2.zero && inDash == false)
        {
            inDash = true;
            speedAtual = dashSpeed;
            Invoke("PostDash", 0.1f);
        }

        if (dir.x > 0)
        {
            this.transform.localScale = new Vector3(0.78f, 0.78f, 1f);
        } else if (dir.x < 0)
        {
            this.transform.localScale = new Vector3(-0.78f, 0.78f, 1f);
        }

        GetComponent<Rigidbody2D>().linearVelocity = dir * speedAtual;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.collidingWithList.Contains(collision.gameObject)) return;
        this.collidingWithList.Add(collision.gameObject);

        CleanHighlight();
        GetFirstCollider();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!this.collidingWithList.Contains(collision.gameObject)) return;
        this.collidingWithList.Remove(collision.gameObject);
        
        CleanHighlight();
        if (this.collidingWithList.Count > 0)
        {
            GetFirstCollider();
            return;
        }

        this.collidingWith = null;
    }

    void DashEnd()
    {
        inDash = false;
    }
    void PostDash()
    {
        speedAtual = speed;
        Invoke("DashEnd", dashCooldown);
    }
    void GetFirstCollider()
    { 
    this.collidingWith = this.collidingWithList
        .FirstOrDefault(obj => !obj.CompareTag("Wall"));

    if (this.collidingWith != null)
    {
        this.collidingWith.GetComponent<SpriteRenderer>().color = this.highlightColor;
    }

        //this.collidingWith = this.collidingWithList.First();
        //this.collidingWith.GetComponent<SpriteRenderer>().color = this.highlightColor;
    }

    void CleanHighlight()
    {
        if (this.collidingWith != null &&
        !this.collidingWith.CompareTag("Wall"))
    {
        this.collidingWith.GetComponent<SpriteRenderer>().color = Color.white;
    }

        //if (this.collidingWith != null) this.collidingWith.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
