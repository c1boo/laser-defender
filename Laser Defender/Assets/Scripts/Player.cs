using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Configuration Paramteres
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.5f;

    //State vars
    float minX, maxX;
    float minY, maxY;

    // Start is called before the first frame update
    void Start() {
        SetUpMovementBoundaries();
    }

    private void SetUpMovementBoundaries() {
        Camera gameCamera = Camera.main;

        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    private void Move() {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        float newPosX = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        float newPosY = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

        transform.position = new Vector2(newPosX, newPosY);
    }
}
