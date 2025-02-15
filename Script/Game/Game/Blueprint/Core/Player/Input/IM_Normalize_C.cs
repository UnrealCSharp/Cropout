using System;
using Script.CoreUObject;
using Script.EnhancedInput;

namespace Script.Game.Blueprint.Core.Player.Input
{
    [Override]
    public partial class IM_Normalize_C
    {
        [Override]
        public override FInputActionValue ModifyRaw(UEnhancedPlayerInput PlayerInput, FInputActionValue CurrentValue, float DeltaTime)
        {
            var X = 0.0;

            var Y = 0.0;

            var Z = 0.0;

            var Type = EInputActionValueType.Boolean;

            UEnhancedInputLibrary.BreakInputActionValue(CurrentValue, ref X, ref Y, ref Z, ref Type);

            var Value = Math.Clamp(X / Normalize_h20_Range, -1.0, 1.0);
            
            return base.ModifyRaw(PlayerInput, UEnhancedInputLibrary.MakeInputActionValueOfType(Value, Value, Value, Type), DeltaTime);
        }
    }
}