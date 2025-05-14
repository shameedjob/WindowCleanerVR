using UnityEngine;

[System.Serializable]
public class SimpleTimer
{
    public float value = 20f;
    public bool resetting = false;
    float _time;
    public void StartTimer(){
        _time = Time.time;
    }

    public bool Finished(){
        if (_time + value < Time.time){
            if (resetting) StartTimer();
            return true;
        }
        else{
            return false;
        }
    }
}
