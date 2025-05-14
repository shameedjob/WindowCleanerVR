using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Wheel: XRBaseInteractable{
    [SerializeField] private Transform wheelTransform;
    public UnityEvent<float> OnWheelRotated;

    private float currentAngle = 0;

    protected override void OnSelectEntered(SelectEnterEventArgs args){
        base.OnSelectEntered(args);
        currentAngle = FindWheelAngle();
    }

    protected override void OnSelectExited(SelectExitEventArgs args){
        base.OnSelectExited(args);
        currentAngle = FindWheelAngle();
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (updatePhase==XRInteractionUpdateOrder.UpdatePhase.Dynamic){
            if(isSelected)
                RotateWheel();
        }
    }

    private float FindWheelAngle(){
        float totalAngle = 0;
        foreach (IXRSelectInteractable interactor in interactorsSelecting){
            Vector2 direction = FindLocalPoint(interactor.transform.position);
            totalAngle += ConvertToAngle(direction) * FindRotationSensitivity();
        }

        return totalAngle;
    }

    void RotateWheel(){
        float totalAngle = FindWheelAngle();

        float angleDifference = currentAngle - totalAngle;
        wheelTransform.Rotate(transform.forward, -angleDifference);

        currentAngle = totalAngle;
        OnWheelRotated?.Invoke(angleDifference);
    }
    Vector2 FindLocalPoint(Vector3 position){
        return transform.InverseTransformPoint(position).normalized;   
    }
    float ConvertToAngle(Vector2 direction){
        return Vector2.SignedAngle(transform.up, direction);
    }

    float FindRotationSensitivity(){
        return 1.0f/interactorsSelecting.Count;
    }
}