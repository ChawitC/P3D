using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grower : MonoBehaviour
{
    [SerializeField] private string playerTag;
    [SerializeField] private string hibernateTrigger;
    [SerializeField] private string growTrigger;
	[SerializeField] private Text FlowerDebugText;

    private Animator animator;
    private bool inTrigger = false;
	private string initText = "Init";
	private float timer = 1; //count down timer to delay animation


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
		FlowerDebugText.text = initText;
    }
	
	// Note to self : if the flower hiberates on start up that's because that's according to the animation flow, not code here
    // Update is called once per frame
    void Update()
    {
		if((Input.GetKeyDown(KeyCode.G)) && inTrigger )
        {
            animator.SetTrigger(growTrigger);
			
        }
		
		if (inTrigger) {FlowerDebugText.text = "In Trigger Zone";}
		else {FlowerDebugText.text = "Not in Trigger Zone";}
		
		// Note to self: test code for timer based hibernation
        /*if((Input.GetKeyDown(KeyCode.G) && inTrigger ))
        {
			timer += 5.0f; //reset timer (approx every 5s)
            animator.SetTrigger(growTrigger);
			//FlowerDebugText.text = "G is being pressed "; //+ timer.ToString("#.00");
			
        }
		//*
		//FlowerDebugText.text = timer.ToString("#.00");
		/*if(timer >= 0.0f) {timer -= Time.deltaTime;} //countdown time by substracting current time
		if(timer <= 0.0f) 
		{
			animator.SetTrigger(hibernateTrigger);
			//FlowerDebugText.text = "Flower Sleeps " + timer.ToString("#.00");
		}
		//*/
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("In here");
        if(other.tag == playerTag)
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Exiting here");
        if (other.tag == playerTag)
        {
            inTrigger = false;
            animator.SetTrigger(hibernateTrigger);
        }
    }
}