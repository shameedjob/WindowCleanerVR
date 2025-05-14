using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Wheel: MonoBehaviour{
    [SerializeField] private Transform wheelTransform;
    public UnityEvent<float> OnWheelRotated;

    private float currentAngle = 0;
    public XRSimpleInteractable selector;

    public void OnSelectEntered(){
        currentAngle = FindWheelAngle();
        text.text = "ENTERED";
    }

    public void OnSelectExited(){
        currentAngle = FindWheelAngle();
        text.text = "EXITED";
    }

    void Update()
    {
        if(selector.isSelected)
            RotateWheel();
    }
    public TextMeshProUGUI text;
    private float FindWheelAngle(){
        float totalAngle = 0;
        foreach (IXRSelectInteractable interactor in selector.interactorsSelecting){
            Vector2 direction = FindLocalPoint(interactor.transform.position);
            totalAngle += ConvertToAngle(direction) * FindRotationSensitivity();
        }

        text.text = totalAngle.ToString();
        return totalAngle;
    }

    void RotateWheel(){
        float totalAngle = FindWheelAngle();
        text.text = totalAngle.ToString();

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
        return 1.0f/selector.interactorsSelecting.Count;
    }
}