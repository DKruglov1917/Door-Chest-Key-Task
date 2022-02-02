using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public PopupSystem popupSystem;
    public float maxInteractRange = 8;

    private void Update()
    {
        Movement();
        Interact();
    }

    private void Interact()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Interactable interactable = hit.transform.GetComponent<Interactable>();

                var heading = transform.position - hit.transform.position;

                if (heading.sqrMagnitude < maxInteractRange)
                {

                    if (hit.collider.tag == "Chest" && !interactable.animator.GetBool("open"))
                    {
                        popupSystem.Popup("Open?", interactable);
                    }

                    if (hit.collider.tag == "Key")
                    {
                        popupSystem.Popup("Take?", interactable);
                    }

                    if (hit.collider.tag == "Door" && GameManager.hasKey)
                    {
                        popupSystem.Popup("Open?", interactable);
                    }
                    else if (hit.collider.tag == "Door" && !GameManager.hasKey)
                    {
                        popupSystem.Popup("You need to find the key first!", interactable);
                    }
                }
            }
        }
    }

    private void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
