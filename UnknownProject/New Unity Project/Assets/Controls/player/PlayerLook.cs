using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the player to interact with elements in the game.
/// </summary>
/// https://docs.unity3d.com/2019.4/Documentation/ScriptReference/Physics.Raycast.html
public class PlayerLook : MonoBehaviour
{
    [Tooltip("Starting point of raycast used to detect interactives.")]
    [SerializeField]
    private Transform raycastOrigin;

    [Tooltip("How far from the raycastOrigin we will search for interactive elements.")]
    [SerializeField]
    private float maxDistance = 5.0f;

    public RectTransform Image;
    public GameObject dm;

    void Start()
    {
        dm = GameObject.Find("DialogueManager");   
    }

    private void FixedUpdate()
    {
        RaycastHit hitInfo;
        bool objectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxDistance);
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxDistance, Color.green);
        /*Interactable interact = null;


        if (objectWasDetected)
        {
            
            Image.sizeDelta = new Vector2(15, 15);
            //Debug.Log("Player is looking at " + hitInfo.collider.gameObject.name);
            interact = hitInfo.collider.gameObject.GetComponent<Interactable>();
        }
        else
        {
            Image.sizeDelta = new Vector2(5, 5);
        }
        if(interact != null && Input.GetButtonDown("Interact") && dm.GetComponent<DialogueManager>().inconvo == false)
        {
            interact.TriggerDialogue();
        }*/
    }

}
