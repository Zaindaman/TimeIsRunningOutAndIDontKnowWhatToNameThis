extends Node
var level_filepath
func change_level(lvl):
	level_filepath = "res://Levels/" + lvl + ".tscn"
	get_tree().change_scene_to_file(level_filepath)

func get_lvl():
	return level_filepath
