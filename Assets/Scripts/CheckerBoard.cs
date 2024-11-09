using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerBoard : MonoBehaviour
{
    public int gridSize = 8; // Tama�o del tablero (N x N)
    public int cellSize = 10; // Tama�o en p�xeles de cada celda (define el grosor de las l�neas)
    public Color lineColor = Color.black; // Color de las l�neas
    public Color backgroundColor = Color.white; // Color de fondo

    void Start()
    {
        // Crear la textura cuadrada de tama�o proporcional a las celdas y el grid
        Texture2D texture = new Texture2D(gridSize * cellSize, gridSize * cellSize);
        texture.filterMode = FilterMode.Point; // Evitar suavizado

        // Recorrer cada p�xel y dibujar el fondo o el borde
        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                // Calcular si estamos en un borde o dentro de una celda
                bool isBorder = (x % cellSize == 0) || (y % cellSize == 0);
                texture.SetPixel(x, y, isBorder ? lineColor : backgroundColor);
            }
        }

        texture.Apply();

        // Asignar la textura a un material del objeto en el que est� este script
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = texture;
    }
}
