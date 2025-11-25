extends CharacterBody2D

var dir = Vector2.ZERO
const SPEED = 96


func _process(delta: float) -> void:
	if dir != 0:
		velocity = dir * SPEED * delta 
func _input(event: InputEvent) -> void:
	if Input.is_action_just_pressed("UP"):
		direction.y = -1
	if Input.is_action_just_pressed("DOWN"):
		dir.y = 1
	if Input.is_action_just_pressed("RIGHT"):
		dir.x = -1
	if Input.is_action_just_pressed("LEFT"):
		dir.x = 1
	else:
		dir = 0
		
