using System;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class TrackController : MonoBehaviour
{
    public Transform trackHolder;
    float trackSpeed = 10;
    int direction = 1;
    public Transform platform;
    int index = 0;
    bool moving = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var points = GetTrackPoints();
        platform.position = points[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (moving){
            
            Vector3[] points = GetTrackPoints();
            int nextIndex = (index+direction)%points.Length;
            float dist = Vector3.Distance(points[index], points[nextIndex]); //20
            float pDist = Vector3.Distance(platform.position, points[nextIndex]); //20
            float a = 1.0f - pDist/dist;
            print(a);

            float delta = GetDelta();
            platform.position = Vector3.Lerp(points[index], points[nextIndex], a + (delta/dist)*trackSpeed);

            if (dist <=  Vector3.Distance(points[index], platform.position) || pDist > dist){
                index = (index+direction)%points.Length;
            }
        }
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
    public void SelectEntered(int direction){
        moving = true;
        this.direction = direction;
    }

    public void SelectExited(){
        moving = false;
    }
}
