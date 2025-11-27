using Godot;
using System;

public partial class BulletSpawner : CharacterBody2D
{
    [Export] public PackedScene Bullet;
    [Export] public float xOffsetDistance = 100f;
    [Export] public float yOffsetDistance = 0f; // Positive Y is down in Godot

    private GlobalValues globalValues;
    private Timer _myTimer;

    public override void _Ready()
    {
        // Must run even if the game tree is paused elsewhere
        ProcessMode = ProcessModeEnum.Always;

        globalValues = GetNode<GlobalValues>("/root/GlobalValues");

        // Assuming "Timer" is a direct child of the BulletSpawner node
        _myTimer = GetNode<Timer>("Timer");
        _myTimer.Start();
        _myTimer.Timeout += _on_timer_timeout; // Connect the Timeout signal
    }

    public override void _Process(double delta)
    {
        // Stop/Start logic is contained here for a custom pause system
        if (globalValues.isBulletTime)
        {
            if (!_myTimer.IsStopped())
            {
                PauseTimer();
            }
        }
        else
        {
            if (_myTimer.IsStopped())
            {
                UnpauseTimer();
            }
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

        BulletLogic newBullet = Bullet.Instantiate<BulletLogic>();

        // 1. Get the direction vectors. Transform.X is the local forward vector, 
        // and Transform.Y is the local up/down vector.
        Vector2 forwardVector = Transform.X;
        Vector2 perpendicularVector = Transform.Y;

        // 2. Calculate offsets without using GlobalScale.X for direction check.
        // Transform.X already accounts for scale flips.
        Vector2 spawnPosition = GlobalPosition
                              + (forwardVector * xOffsetDistance)
                              + (perpendicularVector * yOffsetDistance);

        newBullet.GlobalPosition = spawnPosition;

        // 3. Set the bullet's rotation to match the spawner.
        // This is the clean way to set the bullet's initial direction.
        newBullet.GlobalRotation = GlobalRotation;

        // 4. Tell the bullet to always move forward (Direction = 1). 
        // The rotation handles the facing direction.
        newBullet.SetDirection(1f);

        // Add bullet to the current scene
        GetTree().CurrentScene.AddChild(newBullet);
    }
}