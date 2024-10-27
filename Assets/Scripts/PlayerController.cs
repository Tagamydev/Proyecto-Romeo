using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public	BoardManager boardManager;
    private	Vector2Int currentPosition;
	public	GameObject object_usable;

    private void Start()
    {
        // Initialize the player's starting position
        currentPosition = new Vector2Int(0, 0);
        transform.position = boardManager.GetWorldPosition(currentPosition.x, currentPosition.y);
    }

    private void Update()
	{
		// Handle touch input for mobile
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Ended)
			{
				HandleTouch(touch.position);
			}
		}
		if (Input.GetButtonDown("Fire1"))
        {
            if (object_usable)
            {
                object_usable.GetComponent<Interactable>().Interaction();
            }
        }

		// Optional: For testing in the Unity Editor, handle mouse clicks as well
		if (Input.GetMouseButtonDown(0))
		{
			HandleTouch(Input.mousePosition);
		}
	}


    private void HandleTouch(Vector2 screenPosition)
	{
		// Convert screen position to a ray
		Ray ray = Camera.main.ScreenPointToRay(screenPosition);
		Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);

		if (Physics.Raycast(ray, out RaycastHit hit))
		{
			Vector2Int targetPosition = boardManager.GetGridPosition(hit.point);

			if (boardManager.IsValidMove(targetPosition.x, targetPosition.y))
			{
				MovePlayer(targetPosition);
			}
		}
	}


   private void MovePlayer(Vector2Int targetPosition)
	{
		// Update the current position
		currentPosition = targetPosition;
		
		// Move the player GameObject to the new position on the board
		transform.position = boardManager.GetWorldPosition(currentPosition.x, currentPosition.y);
	}
}
