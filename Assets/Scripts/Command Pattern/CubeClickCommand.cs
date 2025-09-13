using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeClickCommand : ICommand
{
    private GameObject _cube;
    private MeshRenderer _renderer;

    public CubeClickCommand(GameObject cube, Color newColor)
    {
        this._cube = cube;
        _renderer = cube.GetComponent<MeshRenderer>();
    }
    public void Execute()
    {
        throw new System.NotImplementedException();
    }

    public void Undo()
    {
        throw new System.NotImplementedException();
    }

}
