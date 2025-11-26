using Godot;
using System;
using System.Collections.Generic;

public partial class InversionFieldLogic : Area2D
{
    private readonly HashSet<CharacterBody2D> bodiesInField = new();

    // Reference to your GlobalValues node
    [Export] public NodePath GlobalValuesPath;
    private GlobalValues globalValues;

    public override void _Ready()
    {
        ProcessMode = ProcessModeEnum.Always;

        // Get the GlobalValues node
        if (GlobalValuesPath != null)
            globalValues = GetNode<GlobalValues>(GlobalValuesPath);

        BodyEntered += OnBodyEntered;
        BodyExited += OnBodyExited;
    }

    private void OnBodyEntered(Node body)
    {
        // Only apply inversion if bullet time is active
        if (globalValues == null || !globalValues.isBulletTime)
            return;

        var prop = body.GetType().GetProperty("IsInversion");
        if (prop != null)
        {
            prop.SetValue(body, true);
            GD.Print($"{body.Name} entered inversion field (bullet time active)");
        }
    }

    private void OnBodyExited(Node body)
    {
        // Only remove inversion if bullet time is active
        if (globalValues == null || !globalValues.isBulletTime)
            return;

        var prop = body.GetType().GetProperty("IsInversion");
        if (prop != null)
        {
            prop.SetValue(body, false);
            GD.Print($"{body.Name} exited inversion field (bullet time active)");
        }
    }


}