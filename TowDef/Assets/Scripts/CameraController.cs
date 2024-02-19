using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float zoomSpeed = 0.1f;

    private Vector2 touchStart;

    [HideInInspector]
    public Touch touch;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStart = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 direction = touchStart - touch.position;
                direction = new Vector2(direction.x / Screen.width, direction.y / Screen.height);
                transform.Translate(new Vector3(direction.x, 0, direction.y) * panSpeed * Time.deltaTime, Space.World);
            }
        }

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            Vector3 pos = transform.position;
            pos.y += deltaMagnitudeDiff * zoomSpeed; // Zoom sull'asse Y
            pos.y = Mathf.Max(pos.y, 0);
            transform.position = pos;
        }
    }
}



