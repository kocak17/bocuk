using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Copier : Collidable
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
public class Interaction : MonoBehaviour
{

    // Drag the text or image you want to appear here, in the Editor.
    public Text interactionText;

    // How far you can interact with the object from
    public float interactionDistance = 10f;

    void Start()
    {

        // Turns the text off if it isn't already.
        interactionText.gameObject.SetActive(false);
    }

    void Update()
    {

        // Creates a ray going from the camera.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Stores information about what the Raycast hit.
        RaycastHit hit;

        // Raycast for detecting the object.
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {

            // Optional visualization of the ray.
            Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.red);

            // Checks for tag or other condition for recognising the object.
            if (hit.collider.tag == "Interactable")
            {

                // Turns on the interaction prompt.
                interactionText.gameObject.SetActive(true);

                // Interacts with the object upon button press.
                if (Input.GetButtonDown("InteractionButton"))
                {

                    // Do something here, like...

                    // Eg. destroy the object.
                    Destroy(hit.transform.gameObject);
                }

            }
            else
            {

                // Turns the prompt back off when you're not looking at the object.
                interactionText.gameObject.SetActive(false);
            }
        }
    }
}