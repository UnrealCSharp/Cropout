// Fill out your copyright notice in the Description page of Project Settings.

using UnrealBuildTool;
using System.Collections.Generic;

public class CropoutTarget : TargetRules
{
	public CropoutTarget(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Game;

		DefaultBuildSettings = BuildSettingsVersion.Latest;

		ExtraModuleNames.AddRange(new string[] { "Cropout" });
	}
}