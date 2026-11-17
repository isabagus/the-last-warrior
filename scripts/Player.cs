using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 300.0f;
	//public const float JumpVelocity = -400.0f;
	private AnimatedSprite2D animatedSprite2D;
	private Vector2 _lastDirection = Vector2.Down;

	public override void _Ready()
	{
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
	

	public override void _PhysicsProcess(double delta)
	{
		// Vector2 velocity = Velocity;
 		Vector2 direction = Input.GetVector("left", "right", "up", "down");

		Velocity = direction * Speed;

		MoveAndSlide();
		UpdateAnimation(direction);
		
	}

	private void UpdateAnimation(Vector2 direction)
	{
		if (direction != Vector2.Zero)
		{
			_lastDirection = direction;

			if(direction.X != 0)
			{
				animatedSprite2D.FlipH = direction.X < 0;
				animatedSprite2D.Play("walk_right");
			}else if(direction.Y > 0)
			{
				animatedSprite2D.Play("walk_down");
			}else if(direction.X > 0)
			{
				animatedSprite2D.Play("walk_left");
			}else if(direction.Y < 0)
			{
				animatedSprite2D.Play("walk_up");
			}
		}
		else
		{
			if (_lastDirection.X != 0)
			{
				animatedSprite2D.FlipH = _lastDirection.X < 0 ;
				animatedSprite2D.Play("idle_right");
			}else if(_lastDirection.Y > 0)
			{
				animatedSprite2D.Play("idle_down");
			}else if(_lastDirection.X > 0)
			{
				animatedSprite2D.Play("idle_left");
			}else if(_lastDirection.Y < 0)
			{
				animatedSprite2D.Play("idle_up");
			}
		}
	}
}
