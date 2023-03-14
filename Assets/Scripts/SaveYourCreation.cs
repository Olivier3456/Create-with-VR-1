using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveYourCreation : MonoBehaviour
{

    [SerializeField] private Transform placeToSave;

    [SerializeField] private int MAX_POSITIONS = 100;

    public void SaveCreation()
    {
        GameObject[] trails = GameObject.FindGameObjectsWithTag("Trail");
        GameObject parentTrailSave = Instantiate(new GameObject());


        Vector3 offset = placeToSave.position - transform.position;

        

        for (int i = 0; i < trails.Length; i++)
        {
            trails[i].GetComponent<TrailRenderer>().emitting = false;
            trails[i].tag = null;

            Vector3[] TrailRecorded = new Vector3[MAX_POSITIONS];
            int numberOfPositions = trails[i].GetComponent<TrailRenderer>().GetPositions(TrailRecorded);

            for (int j = 0; j < TrailRecorded.Length; j++)
            {
                
                TrailRecorded[j] = TrailRecorded[j] + offset;
                
            }
            trails[i].GetComponent<TrailRenderer>().SetPositions(TrailRecorded);


            //trails[i].transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            //trails[i].transform.SetParent(parentTrailSave.transform);
        }
    }
}
