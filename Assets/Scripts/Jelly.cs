﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public float bounceSpeed;
    public float fallForce;
    public float stiffness;
    private MeshFilter meshFilter;
    private Mesh mesh;
    Vertex[] jellyVertices;
    Vector3[] currentMeshVertices;
    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        GetVertices();

    }

    private void GetVertices()
    {
        jellyVertices = new Vertex[mesh.vertices.Length];
        currentMeshVertices = new Vector3[mesh.vertices.Length];
        for(int i =0; i< mesh.vertices.Length;i++)
        {
            jellyVertices[i] = new Vertex(i, mesh.vertices[i], mesh.vertices[i], Vector3.zero);
            currentMeshVertices[i] = mesh.vertices[i];
            
        }
    }
    private void Update()
    {
        UpdateVertices();
    }

    private void UpdateVertices()
    {
        for (int i = 0; i < jellyVertices.Length; i++)
        {
            jellyVertices[i].UpdateVelocity(bounceSpeed);
            jellyVertices[i].Settle(stiffness);

            jellyVertices[i].currentVelocity += jellyVertices[i].currentVelocity * Time.deltaTime;
            currentMeshVertices[i] = jellyVertices[i].currentVelocity;

        }
        mesh.vertices = currentMeshVertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

    }
    public void OnCollisionEnter(Collision other)
    {
        ContactPoint[] collisonPoints = other.contacts;
        for(int i = 0; i < collisonPoints.Length; i++)
        {
            Vector3 inputPoint = collisonPoints[i].point + (collisonPoints[i].point * .1f);
            ApplyPressureToPoint(inputPoint, fallForce);
        }

    }

    public void ApplyPressureToPoint(Vector3 inputPoint, float fallForce)
    {
        for(int i = 0;i < jellyVertices.Length; i++)
        {
           // jellyVertices[i].ApplyPressueToVertex(transform, );
        }
    }
}