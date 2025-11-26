extends Node2D

@onready var ray = $RayCast2D
@onready var line = $Line2D
signal opendoor
signal closedoor
func _physics_process(delta):
	ray.force_raycast_update()
	if ray.is_colliding():
		var hit_pos = ray.get_collision_point()
		line.points = [Vector2.ZERO, to_local(hit_pos)]
		var collider = ray.get_collider()
		if collider.is_in_group("activator"):
			emit_signal("opendoor")
		else:
			emit_signal("closedoor")
	else:
		line.points = [Vector2.ZERO, ray.target_position]
		
