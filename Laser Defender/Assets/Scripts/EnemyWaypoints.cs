using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypoints : MonoBehaviour {

    [SerializeField] List<GameObject> waypoints;
    [SerializeField] float moveSpeed = 2.0f;
    private int waypointIndex = 0;

    private void Start() {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update() {
        MoveTowards();
    }

    private void MoveTowards() {
        if (waypointIndex <= waypoints.Count - 1) {
            var targetPoisiton = waypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,
                                                    targetPoisiton,
                                                    movementThisFrame);

            if (transform.position == targetPoisiton) {
                waypointIndex++;
            }
        } else {
            Destroy(gameObject);
        }
    }
}
