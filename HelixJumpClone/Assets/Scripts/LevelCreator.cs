
using System;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] GameObject[] discs;
    [SerializeField] int discAmount;
    [SerializeField] float discRange = 1f;
    [SerializeField] Material[] materials;

    GameObject createdDisc;
    float startPoint;
    int discIndex;
    float discRotationAmount;
    Vector3 newPosition;
    Vector3 newRotation;
    private void Awake()
    {
        startPoint = transform.position.y;
        CreateDiscs();
        SetColours();
        
    }

    private void SetColours()
    {
        float r, g, b;
       foreach(Material m in materials)
        {
            r = UnityEngine.Random.Range(0, 1.1f);
            g = UnityEngine.Random.Range(0, 1.1f);
            b = UnityEngine.Random.Range(0, 1.1f);
            m.SetColor("_Color", new Color(r, g, b));
        }

        r = UnityEngine.Random.Range(0, 1.1f);
        g = UnityEngine.Random.Range(0, 1.1f);
        b = UnityEngine.Random.Range(0, 1.1f);
        Camera.main.backgroundColor = new Color(r, g, b);
    }

    private void CreateDiscs()
    {
       for(int i = 0; i<discAmount; i++)
        {
            discIndex = UnityEngine.Random.Range(0, 2);
            discRotationAmount = UnityEngine.Random.Range(0, 360);
            newPosition = transform.position - new Vector3(0, discRange, 0);
            newRotation = new Vector3(0, discRotationAmount, 0);
            createdDisc = Instantiate(discs[discIndex], newPosition, Quaternion.EulerAngles(newRotation));
            createdDisc.transform.parent = transform.parent;
            discRange++;
            

        }
    }

    
}
