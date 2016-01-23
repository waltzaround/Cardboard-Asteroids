#pragma strict

var arena : GameObject;

var arenaWidth = 0;

class TravelDirection {

  var axis : int;
  var sign : int;

  function TravelDirection (axis: int, sign: int) {
    this.axis = axis;
    this.sign = sign;
  }

  function prettyAxis (axis) {
    return (axis == 0) ? "X" :
           (axis == 1) ? "Y" :
           (axis == 2) ? "Z" :
           "?";
  }

  function ToString () {
    return (this.sign > 0 ? "+" : "-") + this.prettyAxis(this.axis);
  }

  static function FromVelocity (v: Vector3) {
    var sign = 1;
    var mag  = 0;
    var dir  = -1;

    for (var i = 0; i <= 2; i++) {
      if (Mathf.Abs(v[i]) > Mathf.Abs(mag)) {
        sign = v[i]/Mathf.Abs(v[i]);
        mag  = v[i];
        dir  = i;
      }
    }

    return new TravelDirection(dir, sign);
  }
}

function Start () {
  arena = GameObject.Find("Arena");
  arenaWidth = arena.GetComponent.<Transform>().lossyScale.x * 2;

  Debug.Log("BoundaryTeleport activated");
}


function msc (v: Vector3) {
}


function Teleport (direction: TravelDirection) {
  var transform = this.gameObject.GetComponent.<Transform>();

  Debug.Log(direction.ToString());
  Debug.Log(arenaWidth * direction.sign);

  transform.position[direction.axis] += arenaWidth * direction.sign;
}


function OnTriggerEnter (coll : Collider) {
  if (coll.gameObject === arena) {
    Debug.Log("This shouldn't happen");
  }
}

function OnTriggerExit (coll: Collider) {
  if (coll.gameObject === arena) {
    Debug.Log("Blam");

    var vel = this.gameObject.GetComponent.<Rigidbody>().velocity;
    Teleport(TravelDirection.FromVelocity(vel));
  }
}

