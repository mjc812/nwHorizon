using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemHandler : MonoBehaviour
{
    public float normalSpeed = 100.0f;
    public float slowSpeed = 20.0f;
    public float fastSpeed = 200.0f;
    public float smoothness = 5.0f;

    private ParticleSystem particleSystem;
    private ParticleSystem.MainModule mainModule;
    private float currentValue = 0.0f;
    private float targetValue = 0.0f;

    void Start()
    {
        currentValue = normalSpeed;
        targetValue = normalSpeed;
        particleSystem = GetComponent<ParticleSystem>();
        mainModule = particleSystem.main;

        CanvasController.OnPromptInputOpen += OnPromptInputOpenHandler;
        CanvasController.OnPromptInputClosed += OnPromptInputClosedHandler;
        PostProcessingHandler.OnTransitionFinished += OnTransitionFinishedHandler;
    }

    void Update()
    {
        if (currentValue != targetValue)
        {
            currentValue = Mathf.Lerp(currentValue, targetValue, Time.deltaTime * smoothness);
            mainModule.startSpeed = currentValue;
            mainModule.startLifetime = normalSpeed/currentValue;
        }
    }

    private void OnPromptInputOpenHandler() {
        targetValue = slowSpeed;
    }

    private void OnPromptInputClosedHandler() {
        targetValue = normalSpeed;
    }
    
    private void OnTransitionFinishedHandler() {
        targetValue = normalSpeed;
    }

}
