using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnObjects : MonoBehaviour
{
	[SerializeField] private string playerTag;
    [SerializeField] private GameObject mObject;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int maxObjects;
    [SerializeField] private Text contextText;
	[SerializeField] private objectivesUpdater objective; //Exposing objectiveUpdater script
    
	private Animator animator;
	private AudioSource audioSource;
    private List<GameObject> mObjects;
    private int numObjects;
	private float timer; //count down timer to delay spawn
	private bool inTrigger = false;
	private int textStage;

    // Start is called before the first frame update
    void Start()
    {
		animator = GetComponentInChildren<Animator>();
        mObjects = new List<GameObject>();   
		textStage = 0;
		/* 
		0 = first zone entry
		1 = E has been pressed (ball spawned)
		2 = F has been pressed (ball picked up)
		*/
    }

    // Update is called once per frame
    void Update()
    {
		
		if((Input.GetKeyDown(KeyCode.E)) && inTrigger )
        {
            if (numObjects < maxObjects)
			{
				SpawnObject(numObjects);
				numObjects++;
				if (textStage == 0) {textStage++;} //change from first stage about E to second stage about F
			}
			//objectivesUpdater.obj2 = true; //Updating objective, since player has already spawned the object
			objective.Obj2done = true;
        }
		
		if (numObjects >= maxObjects && inTrigger) //written as seprate condition otherwise only checked if key is pressed
		{	
			contextText.text = "Maximum number of balls reached";
		}
		else if (inTrigger)
		{
			// cascading tool tips via context message
			if (textStage == 0) {contextText.text = "Press E to spawn a ball";}
			if (textStage == 1) {contextText.text = "Press F to grab the ball(s) close to you and hold them";}
			if (Input.GetKeyDown(KeyCode.F))
			{
				if (textStage <= 1) {textStage=2;} //if F is pressed regardless of E had been pressed when entering the zone or not, progress to last stage
				//This is to consider the case where balls has been left on the mantle
			}
			if(textStage == 2) 
			{
				contextText.text = "Left click to throw the ball(s) forward\nRight click to drop the ball(s) straight down";
			}
		} 
    }

    void SpawnObject(int num)
    {
		var position = spawnPoint.position+ new Vector3(Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f));
		GameObject mObjectClone = Instantiate(mObject, position, Quaternion.identity) as GameObject;
        mObjectClone.SetActive(true);
        mObjects.Add(mObjectClone);
    }
	
	private void OnTriggerEnter(Collider other)
    {
        if(other.tag == playerTag)
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == playerTag)
        {
			inTrigger = false;
			textStage = 0; //Text Stage gets reset
			contextText.text = " "; //reset contextual text
        }
    }
	
}