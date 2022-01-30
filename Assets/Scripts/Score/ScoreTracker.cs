using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
	public float walkSpeed;
	[HideInInspector] public bool moving;
	Rigidbody2D mBody;
	//AnimatorSprite mAnim;

	void Start()
	{
		mBody = GetComponent<Rigidbody2D>();
		//mAnim = GetComponent<AnimatorSprite>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Vector3 vel = new Vector3();
		//bool up, down, right, left;
		//up = false;
		//down = false;
		//right = false;
		//left = false;
		moving = false;

		if (Input.GetKey("w"))
		{
			vel += Vector3.up * walkSpeed * Time.deltaTime;
			//up = true;
			moving = true;
		}
		else if (Input.GetKey("s"))
		{
			vel += Vector3.down * walkSpeed * Time.deltaTime;
			//down = true;
			moving = true;
		}

		// no else here. Combinations of up/down and left/right are fine.
		if (Input.GetKey("a"))
		{
			vel += Vector3.left * walkSpeed * Time.deltaTime;
			//left = true;
			moving = true;
		}
		else if (Input.GetKey("d"))
		{
			vel += Vector3.right * walkSpeed * Time.deltaTime;
			//right = true;
			moving = true;
		}


		mBody.velocity = vel;


        var enemies = GameObject.FindGameObjectWithTag("enemy");
        if(enemies == null){
            SceneManager.LoadScene("SampleScene");
        }
	}

    
}
