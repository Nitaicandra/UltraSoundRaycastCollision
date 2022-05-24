# UltraSoundRaycastCollision
![33YGannetGROUNDUP_-_SampleScene_-_Windows,_Mac,_Linux_-_Uni24_05_2022](https://user-images.githubusercontent.com/89361982/170090687-8fe135b4-aca4-4072-bc68-361561659832.gif)
<details>
<summary>HOW TO USE </summary>
<details>
- YOU set the skin unity model as a trigger object
<details>
- You create an cube and attatch the script to it, these will act as colliders
	- also add rigid body or ontrigger will not work
- you place the colliders onto the surface of the unity probe and then parent them to it
	- from my understanding the probe is either squareish or circlish with a flatish top so i dont think you would need more then 4 ray objects and you may be able to get away with one because from my undnerstanding even though the tip may be wide you will generally have it flat on the surface but i might be wrong on that
	
	- If you do need multiple rays i could write an external script that takes in all of the distances and then averages them by adding them and dividng by the number of objects collided
	-
- THEN WHEN THE PROBE MAKES CONTACT it will return the distance between the closest surface point on the skin to the current object location
- then you would multiply this distance by the compression ratio of the balistic gel
	- ie if it takes 10 grams to push the probe 1cm into the gel then you would multiply the distance by 10 to get the pressure
	- you could proably find the compression ratio by using one of your force probes and mesuring how much force it takes to push in 1cm or you may have been given those stats when you bought the gel
	- i would assume that probes with larger surface area would have higher compression ratios so you may have to do the test with each probe

  
<details>

