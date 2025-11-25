extends Control


func _on_button_pressed() -> void:
	var current_lvl = LevelManager.get_lvl()
	var next_lvl = int(current_lvl) + 1
	LevelManager.change_level(str(next_lvl))


func _on_button_2_pressed() -> void:
	get_tree().change_scene_to_file("res://Scenes/main_menu.tscn")
