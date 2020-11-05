using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ClickOnObject : MonoBehaviourPun
{
    private void OnMouseDown()
    {
        //base.photonView.RequestOwnership();

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            Debug.Log("Target name: " + hit.collider.gameObject.transform.name);
        }
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.velocity = Vector2.up * 10f;
    }
}