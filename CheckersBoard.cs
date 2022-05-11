using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersBoard : MonoBehaviour
{
    public Piece[,] pieces = new Piece[8, 8];

    public GameObject whitePiecePrefab;     // Actual checker piece
    public GameObject blackPiecePrefab;

    private Vector3 boardOffset = new Vector3(-4f, 0, -4f);
    private Vector3 pieceOffset = new Vector3(0.5f, 0, 0.5f);


    private void Start()
    {
        GenerateBoard();
    }

    private void GenerateBoard()
    {
        // Generate White pieces
        for (int y = 0; y < 3; y++)
        {
            bool oddRow = (y % 2 == 0);
            for (int x = 0; x < 8; x += 2)
            {
                // Generate our piece
                GeneratePiece(whitePiecePrefab, oddRow ? x : x + 1, y);
            }
        }

        // Generate Black pieces
        for (int y = 7; y > 4; y--)
        {
            bool oddRow = (y % 2 == 0);
            for (int x = 0; x < 8; x += 2)
            {
                // Generate our piece
                GeneratePiece(blackPiecePrefab, oddRow ? x : x + 1, y);
            }
        }
    }

    private void GeneratePiece(GameObject colorPiece,int x, int y)
    {
        GameObject go = Instantiate(colorPiece);
        go.transform.SetParent(transform);
        Piece p = go.GetComponent<Piece>();
        pieces[x, y] = p;        // Add piece to array
        MovePiece(p, x, y);
    }

    private void MovePiece(Piece p, int x, int y)
    {
        p.transform.position = (Vector3.right * x) + (Vector3.forward * y) + boardOffset + pieceOffset;
    }
}
