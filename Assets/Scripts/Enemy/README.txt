The enemy AI needs this to work properly:

The Player Entity must:
	- Be named 'Player' in the hierarchy
	- Have the 'Player' tag
	- Have the 'Player' layermask
	- Have the 'PlayerTarget' prefab on it (position on player is up to you)

The Enemy AI must have:
	- All the core scripts on it.
	- At least either Melee or Ranged scripts to acutally attack the player
	- Respective subclasses I.E 'MeleeCharge' script needs the 'Melee' script to work

The AIEnabler:
	- Must cover a desired area/room with a collider (The default is box, you can and should
	be able to change it to a different one; and make sure to change it's size.)
	- Must be set as 'IsTrigger = true' or else it will block the player
	- Must have all the entities within it assigned to it's array on the script.