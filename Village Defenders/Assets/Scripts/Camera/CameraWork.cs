using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float movewithKeysSpeed = 50f;
    [SerializeField] private float zoomSpeed = 50;
    [SerializeField] private float minOrthographicSize = 30;
    [SerializeField] private float maxOrthographicSize = 250;
    private AudioListener audioListener;
    private void Start()
    {
        //we set camera to orthoraphic and its rotation
        cam = Camera.main;
        cam.orthographic = true;
        cam.orthographicSize = minOrthographicSize;
        cam.transform.localRotation = Quaternion.Euler(45, 0, 0);
        minOrthographicSize =45;
        //we add an audio listener just in case
        if(audioListener!=null)
        {
            gameObject.AddComponent<AudioListener>();
        }
    }

    void Update()
    {
        //we set the float as axis
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float camUpDown = Input.GetAxis("CamUpDown");
        //we create our vector for x,z movement for vector move
        Vector3 move = new Vector3(horizontal, 0, vertical);
        //we create our vector for y movement for vector orthographicSizeVector
        Vector3 orthographicSizeVector = new Vector3(0, camUpDown, 0);
        transform.Translate(move * movewithKeysSpeed * Time.deltaTime, Space.World);
        float zoom = orthographicSizeVector.y * zoomSpeed * Time.deltaTime;
        float orthographicSize = Mathf.Clamp(cam.orthographicSize - zoom, minOrthographicSize, maxOrthographicSize);

        cam.orthographicSize = orthographicSize;
    }
}
