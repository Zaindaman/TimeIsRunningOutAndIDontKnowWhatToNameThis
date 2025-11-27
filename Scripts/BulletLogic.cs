using Godot;
using System;

public partial class BulletLogic : CharacterBody2D
{
    [Export] public float Speed = 50f; // Increased speed for typical bullet behavior

    private float _direction = 1f; // 1 = right, -1 = left
    private GlobalValues globalValues;

    // A reference to the Area2D node
    private Area2D _area2D;

    public bool isInversion { get; set; } = false;

    public override void _Ready()
    {
        // Get the Area2D node and store the reference
        _area2D = GetNode<Area2D>("Area2D");

        // This makes the Area2D capable of detecting things monitoring it
        // Note: For a bullet, you typically want Monitoring = false and Monitorable = true 
        // if *other* things detect the bullet. But we'll leave it as you set it.
        _area2D.Monitorable = true;

        globalValues = GetNode<GlobalValues>("/root/GlobalValues");
    }

    // Called by the spawner
    public void SetDirection(float spawnerScaleX)
    {
        _direction = MathF.Sign(spawnerScaleX); // +1 or -1
    }

    // Use _PhysicsProcess for movement with MoveAndSlide
    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Vector2.Zero;

        // If NOT in Bullet Time, OR (IF in Bullet Time AND Inversion is ON)
        if (!globalValues.isBulletTime || (globalValues.isBulletTime && isInversion))
        {
            _area2D.Monitorable = true;


            velocity = Transform.X.Normalized() * _direction * Speed;
        }
        else // We are in Bullet Time AND not Inversion
        {
            _area2D.Monitorable = false;
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}