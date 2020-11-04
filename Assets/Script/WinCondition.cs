using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : Movement
{
    [SerializeField] private Transform leftTransform;
    [SerializeField] private Transform rightTransform;
    [SerializeField] private GameObject winPanel;

    [PunRPC]
    protected override void Start()
    {
        base.Start();
       
        if (ball == null)
        {
            print("Ball Not Found");
            return;
        }
        winPanel.SetActive(false);
    }

    [PunRPC]
    private void Update()
    {
        if (ball == null)
        {
            print("Ball Not Found");
            return;
        }

        if ((ball.transform.position.x - leftTransform.position.x) <= 0)
        {
            print("Left Player Wins");
            winPanel.SetActive(true);
        }
        if ((ball.transform.position.x - rightTransform.position.x) >= 0)
        {
            print("Right Player Wins");
            winPanel.SetActive(true);
        }
    }

    [PunRPC]
    public void OnWin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}