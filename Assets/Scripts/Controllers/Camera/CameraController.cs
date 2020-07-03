using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [Header("Settings")]
    public float smoothSpeed = 0.25f;

    [Header("References")]
    [SerializeField] private GameObject bg;
    [SerializeField] private GameObject player;
    [SerializeField] private Camera camera;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        bg = GameObject.FindGameObjectWithTag("Background");    
    }

    // Late Update is called once per frame, after update.
    void LateUpdate() {
        LevelController level = WorldObjects.Level;
        float finalY = player.transform.position.y;

        finalY = Mathf.Clamp(finalY, level.cameraMinY, level.cameraMaxY);

        Vector3 newPos = new Vector3(0.0f, finalY, -10.0f);
        Vector3 smoothedPos = Vector3.Lerp(transform.position, newPos, (smoothSpeed * Time.deltaTime));


        transform.position = smoothedPos;
        bg.transform.position = new Vector3(bg.transform.position.x, smoothedPos.y, bg.transform.position.z);
    }
}
