# UltraSoundRaycastCollision
![33YGannetGROUNDUP_-_SampleScene_-_Windows,_Mac,_Linux_-_Uni24_05_2022](https://user-images.githubusercontent.com/89361982/170090687-8fe135b4-aca4-4072-bc68-361561659832.gif)
<details>
<summary>HOW TO USE </summary>

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
<summary>Inspector Options </summary>
	
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
<summary>code explanation </summary>
- FIRST WE DEFINE TWO COORDINATES IN the LOCAL SPACE OF THE cube
	-
	  ```
	  	  		  public Vector3 default_origin = new Vector3(0f, 0f, -1f);
	  	  		  public Vector3 default_lookat = new Vector3(0f, 0f, 0.5f);
	  ```
	- THESE ARE OUR RAY ORGIN AND RAY LOOKAT
- BY DEFAULT I HAVE
	- the origin set to 0,0,-1 so right behind the object
	- ray lookat to 0,0,0.5 so the center of object
	- EXPLANATION
		- unity cannot detect back faces on convex objects even with Physics.queriesHitBackfaces
		- because the probe will be inside of the skin mesh when pressed in we cannot shoot a ray from insid because it will hit a backface and not register
		- to fix this we have to set the orgin of the ray to outside of the skin object this is why the default orgin is outside of the cube and lookat is inside the cube
		- I imagine the ray_orgin to act simlar to max distance the maximum amount you believe you will push into the balistic gel but you can set this to any value and i dont believe it will effect anything
		- ray lookat is  the first surface of collision the reason its set to 0.5 is because thats the default  z distance of a box colider on a new cube
			- if you change the z dimensions of the box colider you should also change the ray lookat coordinate to match
			- alternativley you could also call the raycast function in an update and ignore collisions entirley and just work off of the raycast collsion but this would likley be less efficient because it runs even when no colision occurs
</details>	
	
	
	
