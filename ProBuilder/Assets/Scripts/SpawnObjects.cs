using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject mObject;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int maxObjects;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timeText;
	[SerializeField] private Text timeNowText;

    private string scorePreText = "Game Score: ";
    private string timePreText = "Total Time: ";
	private string timeNowPreText = "Time Now: ";

    private List<GameObject> mObjects;
    private int numObjects;
	private float timer; //count down timer to delay spawn

    // Start is called before the first frame update
    void Start()
    {
        mObjects = new List<GameObject>();        
        scoreText.text = scorePreText;
        timeText.text = timePreText;
		timeNowText.text = timeNowPreText;
		timer = 0;
		
    }

    // Update is called once per frame
    void Update()
    {
		string gameTimeNow = Time.realtimeSinceStartup.ToString("f2");
		timeNowText.text = timeNowPreText + gameTimeNow + " s";
			
        if (numObjects < maxObjects)
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
                    scoreText.text = scorePreText + count;
                    //Debug.Log("Objects left: " + mObjects.Count);

                    if (mObjects.Count == 0)
                    {                        
                        //Debug.Log("In here? " + gameTime);
                        timeText.text = timePreText + gameTime + " s";
                    }
                }
            }
			
			
        }        

	
    }

    void SpawnObject(int num)
    {
		var position = spawnPoint.position+ new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-0.5f, 0.5f), Random.Range(-2.0f, 2.0f));
		GameObject mObjectClone = Instantiate(mObject, position, Quaternion.identity) as GameObject;
        //GameObject mObjectClone = Instantiate(mObject, spawnPoint.position, Quaternion.identity) as GameObject;
        mObjectClone.SetActive(true);
        mObjects.Add(mObjectClone);
        //Debug.Log("List size " + Objects.Count);
    }
	
}