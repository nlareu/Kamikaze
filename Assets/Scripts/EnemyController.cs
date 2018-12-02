using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float Enemy_Velocity = 0.25f;
    public List<GameObject> ListOfWaypoints;
    public int StartIndex = 0;
    public List<Vector2> waypoints;

    private int currentWaypointIndex;
    private Vector2 _currentWaypont;
    private Vector2 _nextWaypoint;
    private float timer = 5.0f;

    // Use this for initialization
    void Start () {
        this.tag = Tags.ENEMY;

        //If waypoints are not defined, build it automatically
        //depending the initial position of the object.
        if (this.ListOfWaypoints.Count != 0)
            this.ListOfWaypoints.ForEach(item => this.waypoints.Add(item.transform.position));


        this.currentWaypointIndex = this.StartIndex;


        this._currentWaypont = this.waypoints[this.currentWaypointIndex];
        //this._currentWaypont = this.transform.gameObject;

        this.currentWaypointIndex++;

        this._nextWaypoint = this.waypoints[this.currentWaypointIndex];
    }
	
	// Update is called once per frame
	void Update () {
        if (this.waypoints.Count > 0)
        {
            if (this._nextWaypoint != null)
            {
                Vector2 initPos = this._currentWaypont;
                Vector2 endPos = this._nextWaypoint;

                this.timer += Time.deltaTime * this.Enemy_Velocity;

                var newPos = Vector2.Lerp(initPos, endPos, timer);

                this.transform.position = new Vector2(newPos.x, this.transform.position.y);
            }


            if (this.timer >= 1.0f)
            {
                this.timer = 0;

                this._currentWaypont = this._nextWaypoint;

                this.currentWaypointIndex++;

                if (this.currentWaypointIndex == this.waypoints.Count)
                    this.currentWaypointIndex = 0;

                //        if (!this.LoopList && this.StartIndex == this.currentWaypointIndex)
                //        {
                //            /*
                // * Bug:
                // * 	I couldn't make a foreach of <T> so I'll enabled every MonoBehaviour
                // * 	from the enemies. In the future I should look at this
                // * 
                //foreach (var mono in MonoBehavioursCallback) {
                //	GetComponent<typeof(mono)> ().enabled = true;
                //}
                //*/


                //            this.enabled = false;
                //        }
                //        else
                //        {
                this._nextWaypoint = this.waypoints[this.currentWaypointIndex];
                //}

            }
        }
    }
}
