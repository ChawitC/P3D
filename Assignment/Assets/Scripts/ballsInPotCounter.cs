using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballsInPotCounter : MonoBehaviour
{
	int objects = 0;
	[SerializeField] private string ballTag;
	[SerializeField] private Text ballcountText;
	
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Balls in pot: " + objects);
		ballcountText.text = objects.ToString("#");
    }
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == ballTag)
		{
		objects++;
		}
	}


	private void OnTriggerExit(Collider other)
	{
		if(other.tag == ballTag)
		{
		objects--;
		}
	}
}
