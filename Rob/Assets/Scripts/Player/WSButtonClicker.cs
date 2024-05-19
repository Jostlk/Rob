using UnityEngine;

public class WSButtonClicker : MonoBehaviour
{
    private Camera playerCam;

    void Start()
    {
        playerCam = gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if(hit.collider.gameObject.GetComponent<WorldSpaceButton>() != null)
            {
                var button = hit.transform.GetComponent<WorldSpaceButton>();
                button.ButtonClicked();
            }
            
        }
    }
}
