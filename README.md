# Gladeye Hackathon Project: Asteroids

VR Version of Asteroids that can be compiled to either Android or iOS from Unity.

We have a [public Trello board](https://trello.com/b/xh9r1jOj/cardboard-asteroids) available for viewing upcoming 
features and checking the progress of bug fixes.

## Setup Instructions

*	Make sure you are running Unity `5.3.1f1` and XCode 7 as this is the most compatible version with this project to 
    date.

*   When building into XCode for the first time, you may be asked to install the possibly 'incompatible' Unity plugin. 
    Allow it, as this will allow the Unity editor to trigger the clean / build cycle in XCode.

## Build Instructions

Note: there is currently a bug in the Unity `5.3.2x` audio spatializer which breaks `CardboardAudioListener` and causes 
crashing on startup: https://github.com/googlesamples/cardboard-unity/issues/150. On this version of Unity you will need
to disable `CardboardAudioListener` as a workaround. This will mean audio will be disabled.

### iOS

1.	Open in Unity and go to `File -> Build and Run`.

2.	When XCode opens, make sure to add `Security.framework` in the XCode project under 
    `Build Phases -> Link Binary With Libraries` in Project Settings otherwise your will receive a build error.

3.  If you are running Unity 5.3.2, turn off bitcode support in `Build Settings -> Enable Bitcode` and set it to `No` 
    for *Debug* and *Release*

4.  Run *Clean*, *Build* then *Run* on your device.

### Android

1.  Open in unity and go to `File -> Build`.

2.  When you choose android in Build, make sure you choose Landscape left as the default orientation.

## Run Instructions

1.  Deploy the app to your device and run it.

2.  Tap the cog at the bottom of the screen when the game boots up and scan the QR code on your cardboard device.

3.  Stick your device in the Google Cardboard.

### Game Controls

*   Use your head to aim the ship / turret. The turret on the ship is locked to the forward facing direction 
    of the ship and it will shoot where you look if the ship is standing still. If you are moving, there may be some
    slight drift in the stream of plasma released by the turret that you will need to correct for.
    
*   Aiming at an asteroid will cause the white reticule in the centre of the screen to turn red and the turret will 
    automatically open fire.

*   Use the thrusters to move in space. While on, the thrusters will accelerate up to the maximum velocity. When 
    switched off, the ship will glide until it comes to a complete stop. With careful aiming and toggling the thrusters
    the ship can navigate in space and fly around the asteroid field.

#### Thruster Controls for Cardboard V1

*   Pull down and release the magnetic button on the side of the cardboard viewer to toggle thrusters on/off.

#### Thruster Controls for Cardboard V2

*   Tap the button on the right-top side of the cardboard viewer to toggle engines on/off.
