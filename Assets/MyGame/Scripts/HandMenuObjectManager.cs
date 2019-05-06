using System.Collections.Generic;
using UnityEngine;

public class HandMenuObjectManager : MonoBehaviour
{
    public List<GameObject> objectList;
    public List<GameObject> objectPrefabList;
    public int currentObjectIndex = 0;

	void Start ()
    {
        foreach (Transform child in transform)
        {
            objectList.Add (child.gameObject);
        }
	}

    public void MenuLeft ()
    {
        objectList[currentObjectIndex].SetActive (false);
        currentObjectIndex--;

        if (currentObjectIndex < 0)
        {
            currentObjectIndex = objectList.Count - 1;
        }

        objectList[currentObjectIndex].SetActive (true);
    }

    public void MenuRight ()
    {
        objectList[currentObjectIndex].SetActive (false);
        currentObjectIndex++;

        if (currentObjectIndex >= objectList.Count)
        {
            currentObjectIndex = 0;
        }

        objectList[currentObjectIndex].SetActive (true);
    }

    public void SpawnCurrentObject ()
    {
        Instantiate(objectPrefabList[currentObjectIndex], 
            objectList[currentObjectIndex].transform.position, 
            objectList[currentObjectIndex].transform.rotation);
    }
}