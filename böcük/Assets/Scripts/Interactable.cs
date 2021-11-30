using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : Collidable
{
    public GameObject notifier;
    public DialogueTrigger dialogueTrigger;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.gameObject.layer == 9)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueTrigger.TriggerDialogue();
            }
        }
    }

    protected void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.layer == 9)
        {
            notifier.SetActive(true);
        }
    }

    protected void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.layer == 9)
        {
            notifier.SetActive(false);
        }
    }
}
