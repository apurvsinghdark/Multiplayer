using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Resources;

public class Movement : MonoBehaviourPun
{
    protected GameObject ball;
    private InputManager input;

    //[SerializeField] private GameObject prefeb;
    [SerializeField] private Transform target;

    [PunRPC]
    private void Awake()
    {
        //Instantiate(prefeb, target.position, Quaternion.identity);
        input = GetComponent<InputManager>();
    }

    [PunRPC]
    protected virtual void Start()
    {
        //ball = FindObjectOfType<ClickOnObject>().gameObject;
        ball = GameObject.FindGameObjectWithTag("Ball");

        if (ball == null)
        {
            print("Ball Not Found");
            return;
        }
    }

    [PunRPC]
    public void OnLeft()
    {
        ball.transform.position += input.MovementLeft;
    }
    
    [PunRPC]
    public void OnRight()
    {
        ball.transform.position += input.MovementRight;
    }
}