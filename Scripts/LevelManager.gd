extends Node

func change_level(lvl):
	var level_filepath = "res://Levels/" + lvl + ".tscn"
	get_tree().change_scene_to_file(level_filepath)
