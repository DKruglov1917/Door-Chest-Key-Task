using UnityEngine;
using TMPro;

public class PopupSystem : MonoBehaviour
{
    public GameObject popup, yesNoButtons, okButton;
    public PauseManager pauseManager;
    public Animator animator;
    public TMP_Text popupText;
    private Interactable interactable;

    public void Popup(string text, Interactable interactableObject)
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("open_popup"))
        {
            interactable = interactableObject;
            popupText.text = text;
            animator.SetTrigger("pop");

            SetupButtons();
            pauseManager.ManagePause();
        }
    }

    public void AcceptButton()
    {
        interactable.Interact();
    }

    private void SetupButtons()
    {
        if (interactable.gameObject.tag == "Door" && !GameManager.hasKey)
        {
            yesNoButtons.SetActive(false);
            okButton.SetActive(true);
        }
        else
        {
            yesNoButtons.SetActive(true);
            okButton.SetActive(false);
        }
    }
}
