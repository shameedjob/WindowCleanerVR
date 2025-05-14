using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TrackController : MonoBehaviour
{
    public Transform trackHolder;
    float trackSpeed = 5f;
    public int direction = -1;
    public int testTrigger = 0;
    public Transform platform;
    float position = 0;

    public bool moving = true;
    public bool dragging = false;
    bool attach = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static TrackController instance;
    void Start(){
        instance = this;
        var points = GetTrackPoints();
        platform.position = points[0];
        direction = 0;
        moving = false;
        GetComponent<LineRenderer>().positionCount = GetTrackPoints().Length;
        GetComponent<LineRenderer>().SetPositions(GetTrackPoints());
    }

    public float drag;
    public float velocity;
    public int current, next = 0;
    public void WheelSpin(float value){
        velocity += value*trackSpeed;
    }
    Vector3 endPosition;
    public Transform test;
    // Update is called once per frame
    void Update()
    {
        velocity = Mathf.Lerp(velocity, 0, Time.deltaTime*drag);
        // startPosition = Vector3.Lerp(startPosition, GetHandPosition(), Time.deltaTime*8);
        // test.position = endPosition;
        position += velocity*Time.deltaTime;
        if (position > MaxDistance()){
            position -= MaxDistance();
        }
        else if(position < 0){
            position += MaxDistance();
        }

        var distances = GetTrackDistances();
        var positions = GetTrackPoints();
        current = 0;
        for(; position > distances[current]; current++);
        next = (current+1)%distances.Length;
        float left = (current == 0)? 0: distances[current-1];
        float right = distances[current];
        float ratio = (position-left)/(right-left);
        platform.position = positions[current]*(1.0f-ratio) + positions[next]*ratio;
        platform.GetChild(0).rotation = Quaternion.FromToRotation(positions[next]-positions[current],Vector3.right);
    }

    public float GetDelta(){
        return Time.deltaTime;
    }

    public Vector3[] GetTrackPoints(){
        List<Vector3> points = new List<Vector3>();
        for (int i = 0; i < trackHolder.childCount; i++){
            points.Add(trackHolder.GetChild(i).position);
        }
        return points.ToArray(); 
    }

    public float[] GetTrackDistances(){
        List<float> f = new List<float>();
        var points  = GetTrackPoints();
        for(int i = 0; i < points.Length; i++){
            
            f.Add(Vector3.Distance(points[i], points[(i+1)%points.Length]));
        }
        for(int i = 1; i < f.Count; i++){
            f[i]=f[i]+f[i-1];
        }
        
        return f.ToArray();
    }

    public float MaxDistance(){
        return GetTrackDistances()[GetTrackDistances().Length-1];
    }

    public XRBaseInteractable interactable;
    public Vector3 startPosition = Vector3.zero;
    public void SelectEntered(){
        // moving = true;
        startPosition = GetHandPosition();
        attach = true;
    }
    Vector3 GetHandPosition(){
        Vector3 pos = Vector3.zero;
        foreach(var selector in interactable.interactorsSelecting){
            pos += selector.transform.position;
        }
        if (interactable.interactorsSelecting.Count == 0) return Vector2.zero;
        return pos / interactable.interactorsSelecting.Count;
    }

    public void SelectExited(int i){
        moving = false;
        // var endPosition = GetHandPosition();
        // if()
        velocity +=(i*trackSpeed);
        // velocity = 1;
    }
}
