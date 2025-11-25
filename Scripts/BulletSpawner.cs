using Godot;
using System;

public partial class BulletSpawner : CharacterBody2D
{
    [Export]
    public PackedScene Bullet;



    private void _on_timer_timeout()
    {
        GD.Print("Timer timeout!");

        Node2D newBullet = Bullet.Instantiate<Node2D>();

        GetTree().CurrentScene.AddChild(newBullet);

    }

}
