using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Puzzle object class holds necesarry information for each puzzle
public class PuzzleObject
{
    public Vector3 correctPosition;

    public Boundries x;

    public Boundries y;

    public Boundries z;

    public static int correctedPieces = 0;

    public PuzzleObject(
        Vector3 correctPosition,
        Boundries x,
        Boundries y,
        Boundries z
    )
    {
        this.correctPosition = correctPosition;
        this.x = x;
        this.z = z;
        this.y = y;
    }

    public PuzzleObject(Vector3 correctPosition, Boundries x, Boundries z)
    {
        this.correctPosition = correctPosition;
        this.x = x;
        this.z = z;
    }

    public void increaseCorrectedPieces()
    {
        correctedPieces++;
    }

    public void increaseCorrectedPieces(int num)
    {
        correctedPieces = num;
    }

    public int getCorrectedPieces()
    {
        return correctedPieces;
    }

    public void setCorrectedPieces(int num)
    {
        correctedPieces = num;
    }
}

public struct Boundries
{
    public double min;

    public double max;

    public Boundries(double min, double max)
    {
        this.min = min;
        this.max = max;
    }
}
