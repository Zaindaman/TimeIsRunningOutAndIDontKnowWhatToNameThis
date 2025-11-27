extends CharacterBody2D
var centerpos
@export var SPEED = 50
var direction = Vector2.ZERO
var rotationrate : float
var isInversion
@export var XMovement : bool = false
@export var CenterDistance : int = 85
@export var MovementAccelRate : int = 12
# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	centerpos = global_position.x + CenterDistance
	velocity = direction*SPEED
	rotationrate = 0

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:
	if XMovement == true:
		if !GlobalValues.isBulletTime:
			if global_position.x > centerpos:
				velocity.x -= MovementAccelRate
			if global_position.x < centerpos:
				velocity.x += MovementAccelRate
			if rotationrate < 10:
				rotationrate+= 0.2
			
			$Boomerang.rotation_degrees += rotationrate
			
			move_and_slide()
		elif isInversion and !GlobalValues.isBulletTime:
			if global_position.x > centerpos:
				velocity.x -= MovementAccelRate
			if global_position.x < centerpos:
				velocity.x += MovementAccelRate
			if rotationrate <10:
				rotationrate+= 0.2
			
			$Boomerang.rotation_degrees += rotationrate
			
			move_and_slide()
	else:
		if !GlobalValues.isBulletTime:
			if global_position.y > centerpos:
				velocity.y -= MovementAccelRate
			if global_position.y < centerpos:
				velocity.y += MovementAccelRate
			if rotationrate <10:
				rotationrate+= 0.2
			
			$Boomerang.rotation_degrees += rotationrate
			
			move_and_slide()
		elif isInversion and !GlobalValues.isBulletTime:
			if global_position.y > centerpos:
				velocity.y -= MovementAccelRate
			if global_position.y < centerpos:
				velocity.y += MovementAccelRate
			if rotationrate <10:
				rotationrate+= 0.2
			
			$Boomerang.rotation_degrees += rotationrate
			
			move_and_slide()
