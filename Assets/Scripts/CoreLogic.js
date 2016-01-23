#pragma strict


// Shared references

var arena  : GameObject;
var player : GameObject;

var players   = [];
var asteroids = [];


// Engine callbacks

function Start () {

  // Fetch objects we care about
  arena  = GameObject.Find('Arena');
  player = GameObject.Find('Player');

  // Set player moving so I can watch it collide
  var body = player.GetComponent.<Rigidbody>();
  body.AddForce(Vector3.up * 10);

}

