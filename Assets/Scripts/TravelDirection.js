#pragma strict

//
// TravelDirection
//
// A class capturing the notion of an othonormal direction in world space
//

public class TravelDirection {

  var axis : int;
  var sign : int;

  function TravelDirection (axis: int, sign: int) {
    this.axis = axis;
    this.sign = sign;
  }

  function prettyAxis (axis) {
    return (axis == 0) ? "X" : (axis == 1) ? "Y" : (axis == 2) ? "Z" : "?";
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

