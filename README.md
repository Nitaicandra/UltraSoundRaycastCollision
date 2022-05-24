# UltraSoundRaycastCollision
![33YGannetGROUNDUP_-_SampleScene_-_Windows,_Mac,_Linux_-_Uni24_05_2022](https://user-images.githubusercontent.com/89361982/170090687-8fe135b4-aca4-4072-bc68-361561659832.gif)
<details>
<summary>HOW TO USE </summary>

- YOU set the skin unity model as a trigger object
- You create an cube and attatch the script to it, these will act as colliders,also add rigid body or ontrigger will not work

- you place the colliders onto the surface of the unity probe and then parent them to it
- from my understanding the probe end is flat and generally you want to lay them flat to get a reeding so im i think one ray in the midle of the object would work even with very wide probes becaus in the situation of you not laying it flat then i would assume you wouldnt get 
- If you do need multiple rays i could write an external script that takes in all of the distances and then averages them by adding them and dividng by the number of objects collided

- WHEN THE PROBE MAKES CONTACT it will return the distance between the closest surface point on the skin to the current object location
- to get the pressure you would multiply this distance by the compression ratio of the balistic gel
- ie if it takes 10 grams to push the probe 1cm into the gel then you would multiply the distance by 10 to get the pressure
- you could proably find the compression ratio by using one of your force probes and mesuring how much force it takes to push in 1cm or you may have been given those stats when you bought the gel
- i would assume that probes with larger surface area would have higher compression ratios so you may have to do the test with each probe

  


<details>
<summary>Inspector Options </summary>
EDITABLE
- DEFAULT ORGIN AND LOOKAT CAN BE CHANGED BY USER THROUGH THE INSPECTOR
- YOU CAN CHANGE THE axis to point in a diffrent direction if you want, by default its pointin in the z direction
- LAYER MASK CAN ALSO BE CHANGED THROUGH THE INSPECTOR
- compression ratio can be changed through the inspector

DISPLAY
- ray orgins and ray lookat give world cordinates for default orgin and lookat they arnt meant to be changed by user but if you do they will just reset on next collision
- ray length gives the length of the ray
- ray distance gives the distance from ray lookat to closest surface point
- pressure multiplies the compression ratio with the ray_distance
<details>	
	
	
	
	
	
