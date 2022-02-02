using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum InteractableObject
    {
        Chest,
        Door,
        Key
    };

    public delegate void Interacting();
    public static event Interacting OnDoorOpen;

    public InteractableObject interactableObject;
    public Animator animator;
    private Outline outline;

    private void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    public void Interact()
    {
        switch (interactableObject)
        {
            case InteractableObject.Chest:
                animator.SetBool("open", true);
                GetComponent<BoxCollider>().enabled = false;
                break;

            case InteractableObject.Door:
                if (GameManager.hasKey)
                {
                    animator.SetBool("open", true);
                    GetComponent<BoxCollider>().enabled = false;
                    OnDoorOpen?.Invoke();
                }
                break;

            case InteractableObject.Key:
                GameManager.hasKey = true;
                Destroy(gameObject);
                break;
        }
    }

    private void OnMouseOver()
    {
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
