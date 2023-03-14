using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.RenderGraphModule;
using UnityEngine.UIElements;

public class SaveYourCreation : MonoBehaviour
{

    [SerializeField] private Transform placeToSave;

    [SerializeField] private GameObject trailPrefab;

    

    public void SaveCreation()
    {
        GameObject[] trails = GameObject.FindGameObjectsWithTag("Trail");
       

        Vector3 offset = placeToSave.position - transform.position;

        

        for (int i = 0; i < trails.Length; i++)
        {
            TrailRenderer renderer = trails[i].GetComponent<TrailRenderer>();

            Vector3[] TrailRecorded = new Vector3[renderer.positionCount];
            int numberOfPositions = renderer.GetPositions(TrailRecorded);

            for (int j = 0; j < TrailRecorded.Length; j++)
            {                
                TrailRecorded[j] = TrailRecorded[j] + offset;                
            }

            GameObject newTrail = Instantiate(trailPrefab, TrailRecorded[0], trails[i].transform.rotation);
            newTrail.tag = "Finish";

            TrailRenderer actualTrailRendeder = trails[i].GetComponent<TrailRenderer>();
            TrailRenderer newTrailRenderer = newTrail.GetComponent<TrailRenderer>();            
            newTrailRenderer.widthMultiplier = actualTrailRendeder.widthMultiplier;
            newTrailRenderer.startColor = actualTrailRendeder.startColor;
            newTrailRenderer.endColor = actualTrailRendeder.endColor;


            newTrailRenderer.AddPositions(TrailRecorded);
          

            trails[i].SetActive(false);

            
            //trails[i].transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            //trails[i].transform.SetParent(parentTrailSave.transform);
        }
    }
}
