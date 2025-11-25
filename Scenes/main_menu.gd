extends Control


func _on_button_pressed() -> void:
	LevelManager.change_level(0)

func _on_button_2_pressed() -> void:
	get_tree().quit()
