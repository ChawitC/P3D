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
    
	//[Header("Audio")]
	//[Tooltip("An array of footstep sounds. One gets randonly selected to play")]
	//[SerializeField] private AudioClip[] WIPSounds;  

	private Animator animator;
	private AudioSource audioSource;
    private List<GameObject> mObjects;
    private int numObjects;
	private float timer; //count down timer to delay spawn
	private bool inTrigger = false;
	private bool zoneInit;

    // Start is called before the first frame update
    void Start()
    {
		animator = GetComponentInChildren<Animator>();
        mObjects = new List<GameObject>();   
		//audioSource = GetComponent<AudioSource>();	
		zoneInit = false;
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
			}
        }
		
		if (numObjects >= maxObjects && inTrigger) //written as seprate condition otherwise only checked if key is pressed
		{	
			contextText.text = "Maximum number of balls reached";
		}
		if (inTrigger && !zoneInit) 
		{
			contextText.text = "Press E to spawn balls";
			zoneInit = true;
		} 

		/*if (numObjects < maxObjects)
        {
		
			timer -= Time.deltaTime; //countdown time by substracting current time
			if(timer < 0.0f) 
			{
				SpawnObject(numObjects);
				numObjects++;
				timer += 1.0f; //reset timer (approx every 1s)
			}
        } else
        {
            for (int i = 0; i < mObjects.Count; i++)
            {
                if (mObjects[i] == null)
                {
                    string gameTime = Time.realtimeSinceStartup.ToString("f2");
                    mObjects.RemoveAt(i);
                    int count = (maxObjects - mObjects.Count);
                    //scoreText.text = scorePreText + count;
                    //Debug.Log("Objects left: " + mObjects.Count);

                    
                }
            }
			
			
        }*/		

	
    }

    void SpawnObject(int num)
    {
		var position = spawnPoint.position+ new Vector3(Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f));
		GameObject mObjectClone = Instantiate(mObject, position, Quaternion.identity) as GameObject;
        //GameObject mObjectClone = Instantiate(mObject, spawnPoint.position, Quaternion.identity) as GameObject;
        mObjectClone.SetActive(true);
        mObjects.Add(mObjectClone);
        //Debug.Log("List size " + Objects.Count);
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
			zoneInit = false;
			contextText.text = " "; //reset contextual text
        }
    }
	
}