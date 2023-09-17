using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum State
    {
        idle,
        walking,
        swimming,
        climbing
    }
    State currentState = State.idle;
    Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.idle: idle(); break;
            case State.walking: walking(); break;
            case State.swimming: swimming(); break;
            case State.climbing: Climbing(); break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "WaterTrigger")
        {
            currentState = State.swimming;
        }
        else if (other.name == "MountainTrigger")
        {
            currentState = State.climbing;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        currentState = State.walking;
    }

    void idle()
    {
        Debug.Log("idle");
        if(lastPos != transform.position)
        {
            currentState = State.walking;
        }
    }
    void walking()
    {
        Debug.Log("walking");
        if (lastPos == transform.position)
        {
            currentState = State.idle;
        }
        lastPos = transform.position;
    }
    void swimming()
    {
        Debug.Log("swimming");
    }
    void Climbing()
    {
        Debug.Log("climbing");
    }
}
