using System.Collections.Generic;
using UnityEngine;

public class HandMenuObjectManager : MonoBehaviour
{
    public List<GameObject> objectPrefabList;
    public int currentObjectIndex = 0;
    public List<GameObject> previewItemList;

    public void MenuLeft ()
    {
        Debug.Log("in Menu Left");
        Debug.Log("preview length" + previewItemList.Count);
        previewItemList[currentObjectIndex].SetActive (false);
        currentObjectIndex--;

        if (currentObjectIndex < 0)
        {
            currentObjectIndex = previewItemList.Count - 1;
        }

        previewItemList[currentObjectIndex].SetActive (true);
    }

    public void MenuRight ()
    {
        previewItemList[currentObjectIndex].SetActive (false);
        currentObjectIndex++;

        if (currentObjectIndex >= previewItemList.Count)
        {
            currentObjectIndex = 0;
        }

        previewItemList[currentObjectIndex].SetActive (true);
    }

    public void SpawnCurrentObject ()
    {
        Instantiate(objectPrefabList[currentObjectIndex], 
            previewItemList[currentObjectIndex].transform.position, 
            previewItemList[currentObjectIndex].transform.rotation);
    }
}