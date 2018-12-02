using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : MonoBehaviour {

    public float Speed = 1f;

    private Rigidbody2D rigidBody;

    // Use this for initialization
    void Start () {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.tag = "Bullet";
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        this.rigidBody.AddForce(Vector2.down * this.Speed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Object.Destroy(this.gameObject);
    }
}
