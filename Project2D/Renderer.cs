﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;
using MathClasses;

//--------------------------------------------------------------
// Functions for use with custom math library
//--------------------------------------------------------------
static public class Renderer
{
	//--------------------------------------------------------------
	//--------------------------------------------------------------
	public static Vector2 ToVector2(this Vector2 vec)
	{
		Vector2 result;
		result.x = vec.x;
		result.y = vec.y;

		return result;
	}
	
	//--------------------------------------------------------------
	//--------------------------------------------------------------
	public static Colour ToColor(this Colour colour)
	{
		return new Colour(colour.GetRed(), colour.GetGreen(), colour.GetBlue(), colour.GetAlpha());
	}

	//--------------------------------------------------------------
	//--------------------------------------------------------------
	public static Colour ToColour(this Colour color)
	{
		Colour col = new Colour(0x12, 0x34, 0x56, 0x78);
		col.SetRed(color.r);
		col.SetGreen(color.g);
		col.SetBlue(color.b);
		col.SetAlpha(color.a);

		return col;
	}

	//--------------------------------------------------------------
	//--------------------------------------------------------------
	public static Vector2 GetMousePosition()
	{
		RLVector2 pos = Raylib.Raylib.GetMousePosition();
		return pos.ToRLVector2();
	}

	//--------------------------------------------------------------
	//--------------------------------------------------------------
	public static void DrawLine(Vector2 startPos, Vector2 endPos, float thick, Colour colour)
	{
		DrawLineEx(startPos.ToVector2(), endPos.ToVector2(), thick, colour.ToColour());
	}

	//--------------------------------------------------------------
	//--------------------------------------------------------------
	public static void DrawCircle(Vector2 center, float radius, Colour colour)
	{
		DrawCircleV(center.ToVector2(), radius, colour.ToColour());
	}

	//--------------------------------------------------------------
	//--------------------------------------------------------------
	public static void DrawRectangle(Vector2 position, Vector2 size, Colour colour)
	{
		DrawRectangleV(position.ToVector2(), size.ToVector2(), colour.ToColour());
	}

	//--------------------------------------------------------------
	//--------------------------------------------------------------
	public static void DrawText(Font font, string text, Vector2 position, float fontSize, float spacing, Colour tint)
	{
		DrawTextEx(font, text, position.ToVector2(), fontSize, spacing, tint.ToColour());
	}

	//--------------------------------------------------------------
	//--------------------------------------------------------------
	public static void DrawTexture(Texture2D texture, Matrix3 transform, Colour color)
	{
		Vector2 xAxis = new Vector2();
		xAxis.x = transform.m[0];
		xAxis.y = transform.m[1];

		Vector2 yAxis = new Vector2();
		yAxis.x = transform.m[3];
		yAxis.y = transform.m[4];

		//Note - the angle of a unit circle count up when they go anticlockwise,
		//but because in Raylib land positive Y is down, a positive angle will
		//be clockwise.
		float angle = (float)Math.Atan2(xAxis.y, xAxis.x);
		float scaleX = xAxis.Magnitude();
		float scaleY = yAxis.Magnitude();

		//The portion of the image to render
		Rectangle source = new Rectangle();
		source.width = texture.width;
		source.height = texture.height;

		//Origin to rotate around
		Vector2 origin = new Vector2();
		origin.x = texture.width * 0.5f;
		origin.y = texture.height * 0.5f;

		//The target position and size to render at
		Rectangle destination = new Rectangle();
		destination.x = transform.m[6];
		destination.y = transform.m[7];
		destination.width = source.width * scaleX;
		destination.height = source.height * scaleY;

		//We multiply the angle by 180/pi because the matrix library for the project
		//works in radians (that's what the unit tests require) but RayLib expects degrees.
		float degrees = angle * 180.0f / (float)Math.PI;

		//Convert our color class to a raylib colour
		Colour Colour = new Colour(color.GetRed(), color.GetGreen(), color.GetBlue(), color.GetAlpha());

		//Draw texture
		DrawTexturePro(texture, source, destination, origin, degrees, Colour);
	}
}
