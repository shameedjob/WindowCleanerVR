using System;
using System.Collections.Generic;
using System.Linq;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class TrackController : MonoBehaviour
{
    public Transform trackHolder;
    float trackSpeed = 10;
    public int direction = -1;
    public int testTrigger = 0;
    public Transform platform;
    float position = 0;

    public bool moving = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var points = GetTrackPoints();
        platform.position = points[0];
        direction = 0;
        moving = false;
        GetComponent<LineRenderer>().positionCount = GetTrackPoints().Length;
        GetComponent<LineRenderer>().SetPositions(GetTrackPoints());
    }

    public float drag;
    float velocity;

    public void WheelSpin(float value){
        velocity += value;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Mathf.Lerp(velocity, 0, Time.deltaTime*drag);
        position += trackSpeed*velocity*Time.deltaTime;
        if (position > MaxDistance()){
            position -= MaxDistance();
        }
        else if(position < 0){
            position += MaxDistance();
        }
        print(position);

        var distances = GetTrackDistances();
        var positions = GetTrackPoints();
        int current = 0;
        for(; position > distances[current]; current++);
        int next = (current+1)%distances.Length;
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

    public void SelectEntered(int direction){
        moving = true;

        this.direction = direction;
    }

    public void SelectExited(){
        moving = false;
    }
}
