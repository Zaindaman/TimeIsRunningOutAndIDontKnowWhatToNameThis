extends Control


func _on_button_pressed() -> void:
	LevelManager.change_level("test_scene_main")

func _on_button_2_pressed() -> void:
	get_tree().quit()
