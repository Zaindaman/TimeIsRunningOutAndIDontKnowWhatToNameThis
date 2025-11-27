using Godot;
using System;

public partial class BulletLogic : CharacterBody2D
{
    // Adjusted Speed for less jitter and more typical bullet appearance
    [Export] public float Speed = 800f;

    private float _direction = 1f; // 1 = forward, -1 = backward (now always 1)
    private GlobalValues globalValues;

    // A reference to the Area2D node
    private Area2D _area2D;

    public bool isInversion { get; set; } = false;

    public override void _Ready()
    {
        // Must run even if the game tree is paused elsewhere
        ProcessMode = ProcessModeEnum.Always;

        // Ensure you have a child Area2D named "Area2D" in your bullet scene
        _area2D = GetNode<Area2D>("Area2D");
        _area2D.Monitorable = true;

        globalValues = GetNode<GlobalValues>("/root/GlobalValues");
    }

    // Called by the spawner. Now typically called with 1f.
    public void SetDirection(float baseDirection)
    {
        _direction = baseDirection;
    }

    // Movement must be handled in _PhysicsProcess for CharacterBody2D
    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Vector2.Zero;

        // --- Bullet Movement Logic ---

        // If NOT in Bullet Time, OR (IF in Bullet Time AND Inversion is ON)
        if (!globalValues.isBulletTime || (globalValues.isBulletTime && isInversion))
        {
            // Enable monitoring/collision detection
            _area2D.Monitorable = true;

            // FIX for Jitter: Rely purely on the bullet's current rotation (Transform.X) 
            // for the forward vector. This is guaranteed to be consistent.
            velocity = Transform.X * _direction * Speed;
        }
        else // We are in Bullet Time AND not Inversion (STOP)
        {
            // Disable monitoring/collision detection while the bullet is frozen
            _area2D.Monitorable = false;
            // velocity remains Vector2.Zero, causing the bullet to stop
        }

        // --- CharacterBody2D Movement ---

        Velocity = velocity;
        MoveAndSlide();
    }
}