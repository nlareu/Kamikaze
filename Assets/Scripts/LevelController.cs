using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public float Speed = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 moveVector = new Vector2();
        moveVector += Vector2.down * this.Speed * Time.deltaTime;

        this.transform.Translate(moveVector);	
	}
}
