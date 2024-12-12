using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEnventReceiver : MonoBehaviour
{
    public CanvasController.CanvasState stateListening; 
    private CanvasController canvasController;
    private Animator animator;
    private float Direction=-1;
    // Start is called before the first frame update
    void Start()
    {
        canvasController = CanvasController.instance;
        animator = GetComponent<Animator>();
        canvasController.canvasEvent += onCanvasEvent;
    }
    private void Enter() {
        animator.SetFloat("Direction", Direction);
    }
    void onCanvasEvent(CanvasController.CanvasState state) {
        if (animator == null) return;
        if (state == stateListening) {
            Direction = 1;
            Invoke(nameof(Enter), 1.0f);
        } else {
            Direction = -1;
            animator.SetFloat("Direction", -1);
        }
    }

}
