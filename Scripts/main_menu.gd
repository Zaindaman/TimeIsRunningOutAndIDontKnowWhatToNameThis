extends Control


func _on_button_pressed() -> void:
	$Button.visible = false
	$Button2.visible = false
	$"Lvl Selector".visible = true
	

func _on_button_2_pressed() -> void:
	get_tree().quit()


func _on_button_lvl_pressed(sender_node) -> void:
	LevelManager.change_level(str(sender_node))


func _on_button_6_pressed(extra_arg_0: String) -> void:
	pass # Replace with function body.
