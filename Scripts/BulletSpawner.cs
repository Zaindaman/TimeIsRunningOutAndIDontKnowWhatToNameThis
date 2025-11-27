using Godot;
using System;

public partial class BulletSpawner : CharacterBody2D
{
    [Export] public PackedScene Bullet;
    [Export] public float offsetDistance = 100f;

    private GlobalValues globalValues;

    private Timer _myTimer;

    public override void _Ready()
    {
        ProcessMode = ProcessModeEnum.Always;

        globalValues = GetNode<GlobalValues>("/root/GlobalValues");


        _myTimer = GetNode<Timer>("/Timer"); // Replace "MyTimerNode" with your Timer's path
        _myTimer.Timeout += _on_timer_timeout; // Connect the Timeout signal
    }

    public void _process()
    {
        if (globalValues.isBulletTime)
        {
            PauseTimer();
        }
        else
        {
            UnpauseTimer();
        }
    }

    public void PauseTimer()
    {
        _myTimer.Stop();
    }

    public void UnpauseTimer()
    {
        _myTimer.Start();
    }

       
    private void _on_timer_timeout()
    {
        if (Bullet == null)
            return;

        // Instantiate the bullet
        BulletLogic newBullet = Bullet.Instantiate<BulletLogic>();

        // Spawn position: offset in the direction the spawner is facing
        Vector2 spawnPosition = GlobalPosition + Transform.X * offsetDistance * MathF.Sign(GlobalScale.X);
        newBullet.Position = spawnPosition;

        // Set the bullet's movement direction based on spawner's X scale
        newBullet.SetDirection(GlobalScale.X);

        // Optional: match bullet rotation to spawner
        newBullet.GlobalRotation = GlobalRotation;

        // Add bullet to the current scene
        GetTree().CurrentScene.AddChild(newBullet);
    }
}