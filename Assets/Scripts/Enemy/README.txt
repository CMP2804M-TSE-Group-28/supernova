The enemy AI needs this to work properly:

The Player Entity must:
	- Be named 'Player' in the hierarchy
	- Have the 'Player' tag
	- Have the 'Player' layermask
	- Have the 'PlayerTarget' prefab on it (position on player is up to you)

The enemy AI must have:
	- All the core scripts on it.
	- At least either Melee or Ranged scripts to acutally attack the player
	- Respective subclasses I.E 'MeleeCharge' script needs the 'Melee' script to work