using Godot;
using System;

public partial class GlobalValues : Node
{
	public bool isBulletTime { get; set; }
	public bool isGameOver { get; set; }
	public bool isGameStart { get; set; }
	public int[] levelNumber{ get; set; }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ProcessMode = ProcessModeEnum.Always;

	}

}
