using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraInitAnim : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke(nameof(initAnimEnd), 1.1f);
    }
    void initAnimEnd() {
        Destroy(animator);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
