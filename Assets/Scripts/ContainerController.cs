using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerController : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] Transform item;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    public bool HaveItem()
    {
        return this.item != null;
    }

    public Transform GetItem()
    {
 
        Transform itemToReturn = this.item;
        this.item = null;
        audioManager.PlaySFX(audioManager.steps);

        return itemToReturn;
    }

    public void SetItem(Transform _item)
    {
        this.item = _item;
        audioManager.PlaySFX(audioManager.steps);
    }
}
