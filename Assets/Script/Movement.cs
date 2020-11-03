using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    protected GameObject ball;
    InputManager input;

    [SerializeField]private GameObject prefeb;
    [SerializeField]private Transform target;

    private void Awake() {
        Instantiate(prefeb ,target.position ,Quaternion.identity);
        input = GetComponent<InputManager>();
    }

    protected virtual void Start() {
        ball = FindObjectOfType<ClickOnObject>().gameObject;
    }

    public void OnLeft()
    {
        ball.transform.position += input.MovementLeft;
    }
    public void OnRight()
    {
        ball.transform.position += input.MovementRight;
    }
}
