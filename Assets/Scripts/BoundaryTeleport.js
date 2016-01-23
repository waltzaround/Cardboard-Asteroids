#pragma strict


// State

var arena : GameObject;
var arenaWidth = 0;


// Functions

function WrapTeleport (direction: TravelDirection) {

  // For some reason, accessing transform in this way returns a copy.
  // So just modify the copy and assign it back to the transform object.

  var pos = this.gameObject.GetComponent.<Transform>().position;
  pos[direction.axis] += arenaWidth * -direction.sign;
  transform.position = pos;
}


// Engine Hooks

function Start () {
  // Find and measure arena for collision
  arena      = GameObject.Find("Arena");
  arenaWidth = arena.GetComponent.<Transform>().lossyScale.x;
}

function OnTriggerExit (coll: Collider) {
  if (coll.gameObject === arena) {
    var vel = this.gameObject.GetComponent.<Rigidbody>().velocity;
    WrapTeleport(TravelDirection.FromVelocity(vel));
  }
}

