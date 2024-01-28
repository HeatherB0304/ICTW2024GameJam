using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // Reference to the Animator component
    private Animator animator;

    // Time to wait before the start of each loop
    public float idleTime = 30f; // You can adjust this value as needed

    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();

        // Start the loop coroutine
        StartCoroutine(AnimationLoop());
    }

    // Coroutine for the animation loop
    IEnumerator AnimationLoop()
    {
        while (true)
        {
            // Wait for idleTime before starting the loop
            yield return new WaitForSeconds(idleTime);

            // Play the first animation
            PlayAnimation("upTrigger");

            // Wait for 20 seconds
            yield return new WaitForSeconds(20f);

            // Play the second animation
            PlayAnimation("downTrigger");

            // Wait for 20 seconds
            yield return new WaitForSeconds(20f);
        }
    }

    // Function to play an animation based on the trigger parameter
    void PlayAnimation(string triggerName)
    {
        // Set a trigger parameter to start the animation
        animator.SetTrigger(triggerName);
    }
}
