using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public int boardWidth = 8;
    public int boardHeight = 8;
    public float tileSize = 1.0f;

    // Convert grid coordinates to world position
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, 1, y);
    }

    // Get grid position from world coordinates
    public Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x);
        int y = Mathf.FloorToInt(worldPosition.z);

		// Log the calculated grid position
    	Debug.Log($"Calculated Grid Position from World Position ({worldPosition.x}, {worldPosition.z}): ({x}, {y})");

		// Clamp the coordinates to the GameBoard limits (optional)
		x = Mathf.Clamp(x, -40, 40);
		y = Mathf.Clamp(y, -40, 40);

        return new Vector2Int(x, y);
    }

    // Check if the move is within the board's bounds
	public bool IsValidMove(int x, int y)
	{
		// Update the boundaries based on your GameBoard's actual size
		int minX = -40;
		int maxX = 40;
		int minY = -40;
		int maxY = 40;

		// Check if the target position is within the valid range
		return x >= minX && x <= maxX && y >= minY && y <= maxY;
	}
}

