using UnityEngine;

public class Trash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collider object other name " + other.gameObject.name);
        if (other.gameObject.name == "Fan_Body")
        {
            Destroy(other.GetComponent<Transform>().parent.gameObject);
        }
        else if (other.gameObject.name.Contains("Wood_Plank"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.name == "GravityZoneCylinder")
        {
            Destroy(other.GetComponent<Transform>().parent.gameObject);
        }
        else if (other.gameObject.name == "TrampolineJumpArea")
        {
            Destroy(other.GetComponent<Transform>().parent.gameObject);
        }
    }

}
