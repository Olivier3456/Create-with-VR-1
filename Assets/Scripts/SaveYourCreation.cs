using System.Collections;
using System.Collections.Generic;
using System.Xml.Xsl;
using UnityEngine;
using UnityEngine.Experimental.Rendering.RenderGraphModule;
using UnityEngine.UIElements;

public class SaveYourCreation : MonoBehaviour
{

    [SerializeField] private Transform placeToSave;

    [SerializeField] private GameObject trailPrefab;

    [SerializeField] private float reductionFactor = 3;


    public void SaveCreation()
    {
        GameObject[] trails = GameObject.FindGameObjectsWithTag("Trail");
        Mesh trailMesh = new Mesh();


        //Vector3 offset = placeToSave.position - transform.position;


        for (int i = 0; i < trails.Length; i++)
        {
            TrailRenderer renderer = trails[i].GetComponent<TrailRenderer>();
            renderer.BakeMesh(trailMesh, true);
            //renderer.BakeMesh(trailMesh, Camera.main, true);

            GameObject trailObject = new GameObject("Trail Save");


            #region Calcule la position moyenne des vertices de la trail pour l'appliquer en offset à toutes les positions des vertices et les relocaliser.
            Vector3[] TrailRecorded = new Vector3[renderer.positionCount];
            int numberOfPositions = renderer.GetPositions(TrailRecorded);
            Vector3 averagePosition = Vector3.zero;

            for (int j = 0; j < TrailRecorded.Length; j++)
            { averagePosition += TrailRecorded[j]; }
            averagePosition /= TrailRecorded.Length;

            for (int j = 0; j < TrailRecorded.Length; j++)
            { TrailRecorded[j] += averagePosition; }
            #endregion


            MeshFilter meshFilter = trailObject.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = trailObject.AddComponent<MeshRenderer>();
            meshFilter.sharedMesh = trailMesh;
            trailObject.transform.position = placeToSave.position;
            trailObject.transform.localScale = trailObject.transform.localScale / reductionFactor;

            Material material = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
            material.color = renderer.startColor;
            meshRenderer.material = material;



            #region Méthode de déplacement de la trail en créant une nouvelle trail pour y mettre les coordonnées des vertices de l'ancienne, avec un offset (fonctionne).
            //TrailRenderer renderer = trails[i].GetComponent<TrailRenderer>();
            //Vector3[] TrailRecorded = new Vector3[renderer.positionCount];
            //int numberOfPositions = renderer.GetPositions(TrailRecorded);

            //for (int j = 0; j < TrailRecorded.Length; j++)
            //{                
            //    TrailRecorded[j] = TrailRecorded[j] + offset;                
            //}

            //GameObject newTrail = Instantiate(trailPrefab, TrailRecorded[0], trails[i].transform.rotation);
            //newTrail.tag = "Finish";

            //TrailRenderer actualTrailRenderer = trails[i].GetComponent<TrailRenderer>();
            //TrailRenderer newTrailRenderer = newTrail.GetComponent<TrailRenderer>();            
            //newTrailRenderer.widthMultiplier = renderer.widthMultiplier / reductionFactor;
            //newTrailRenderer.startColor = renderer.startColor;
            //newTrailRenderer.endColor = renderer.endColor;

            //newTrailRenderer.AddPositions(TrailRecorded);

            //trails[i].SetActive(false);
            #endregion
        }
    }
}
