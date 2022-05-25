# UltraSoundRaycastCollision
![33YGannetGROUNDUP_-_SampleScene_-_Windows,_Mac,_Linux_-_Uni24_05_2022](https://user-images.githubusercontent.com/89361982/170090687-8fe135b4-aca4-4072-bc68-361561659832.gif)
<details>
<summary>
## HOW TO USE 
</summary>

### SETUP
- set the skin unity model as a trigger object
- create an cube and attatch the script to it, these will act as colliders, also add rigid body or ontrigger will not work


### APPLY COLLDIERS 
- place the colliders onto the surface of the unity probe and then parent them to it 

- Im unsure if the probe is flat or rounded if its flat 1 ray is proabably enough even forwide models if its roudned you may need a few rays

- If you do need multiple rays i could write an external script that takes in all of the distances and then averages them by adding them and dividng by 
the number of objects collided

### Pressure
- when the probe makes contact it will return the distance between the closest surface point on the skin to the current object location
to get the pressure you would multiply this distance by the compression ratio of the balistic gel

- ie if it takes 10 grams to push the probe 1cm into the gel then you would multiply the distance by 10 to get the pressure
you could proably find the compression ratio by using one of your force probes and mesuring how much force it takes to push in 1cm or you may have been given those stats when you bought the gel

- i would assume that probes with larger surface area would have higher compression ratios so you may have to do the test with each probe
	
</details>
  


<details>
<summary>
## INSPECTOR OPTIONS
</summary>
	
### EDITABLE
- DEFAULT ORGIN AND LOOKAT CAN BE CHANGED BY USER THROUGH THE INSPECTOR
- YOU CAN CHANGE THE axis to point in a diffrent direction if you want, by default its pointin in the z direction
- LAYER MASK CAN ALSO BE CHANGED THROUGH THE INSPECTOR
- compression ratio can be changed through the inspector

### DISPLAY
- ray orgins and ray lookat give world cordinates for default orgin and lookat they arnt meant to be changed by user but if you do they will just reset on next collision
- ray length gives the length of the ray
- ray distance gives the distance from ray lookat to closest surface point
- pressure multiplies the compression ratio with the ray_distance
</details>	

<details>
<summary>
## CODE EXPLANATIONS 
</summary>

	
### RAY
- We define the ray in local coordinats then convert them to global so that the ray is locked to the cubes axis
-
- by default
- the origin is set to 0,0,-1 so right behind the object
- ray lookat is set to 0,0,0.5 so the center of object
### WHY
- unity cannot detect back faces on convex objects even with Physics.queriesHitBackfaces
- because the probe will be inside of the skin mesh when pressed in we cannot shoot a ray from insid because it will hit a backface and not register
- to fix this we have to set the orgin of the ray to outside of the skin object and shoot inwards in the same direction as if we shot outwards this is why the default orgin is outside of the cube and lookat is inside the cube
- I imagine the ray_orgin to act simlar to max distance, the maximum amount you believe you will push into the balistic gel but you can set this to any value and i dont believe it will effect anything as long as its starts outside of the the skin
- ray lookat is  the first surface of collision the reason its set to 0.5 by default is because thats the default  z distance of a box colider on a new cube
- alternativly you could set the collision to the orgin of the cube and use the collision box as just a trigger to activate the ray even and have them be uncoorilated
### MISC
- Local coordinates will follow rotation of the cube so you will be able to change the direction of the ray by simply rotating the object
- ray_lookat-ray orgin gives you a new vector that points in the same direction as the line formed by points rayorgin to raylookat
- to get the distance between the nearest surface point and the cube you have to use vectro3.Distance() in this case you cannot use hit.distance because the ray is on the outside of the surface	
</details>
---
<details>
<summary>
### UPDATE1 , removed ontrigger , probe 3 point test
</summary>


- replace ontriggerenter with a simple update only thing needed is a colider on the skin object 
- Changed default ray orgin from 0,0,-1 to 0,-0.1,0   this causes the ray to pointing up instead of forward and shrinks the length
- changed default lookat from 0,0,0.5 to 0,0,0 now the orgin dictates the colision point
- seems to work with fairly well when parenting to the probe
- i dont believe its possible to snap objects to the normal of vertices in unity so i suggest using blender to do this
- for the probe model i would suggest using a 3 8 or 11 point ray
## FLOAT ARRAY if you input these switch the y and z blender has z as up by default
- TOP [-0.022241,-0.000014,0.045321][-0.000127,-0.000014,0.045321][0.022242,-0.000014,0.045321] Rotation [0,0,0]
- LEFT[-0.026144,0,0.043466]Rotation [-192.588,-133.125,197.012]
- RIGHT[0.026144,0,0.043466]Rotation [-160.764,-225.04,206.249]
- Forward[0,-0.005315,0.042514] Rotation[-118.282,-179.871,180.069]
- Back[0,0.005315,0.042514] Rotation[-241.432,-180,180]

</details>

![33UConyGROUNDUP_-_SampleScene_-_Windows,_Mac,_Linux_-_Uni24_05_2022](https://user-images.githubusercontent.com/89361982/170150335-b89529a3-df3d-44b7-91c7-174583fbb424.gif)	
<details>
<summary>
### UPDATE2
</summary>
	
- added vein collapse detector which logs every detector that has a reading over a user defined threshold
- raycaster objects should be tagged with raycast in order to be checked for vein collapse
- added skin layermask and tags to startup function on raycast script
</details>
