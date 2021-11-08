using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OOBwarning : MonoBehaviour
{
	[SerializeField] private string playerTag;
	[SerializeField] private Text contextText;
	
	private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("In here");
        if(other.tag == playerTag)
        {
            contextText.text = "You can't go that way!"; //reset contextual text
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Exiting here");
        if (other.tag == playerTag)
        {
			contextText.text = " "; //reset contextual text
        }
    }
	
}
