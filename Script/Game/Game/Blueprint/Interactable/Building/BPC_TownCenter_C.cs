using System.Threading;
using System.Threading.Tasks;
using Script.CoreUObject;
using Script.Engine;

namespace Script.Game.Blueprint.Interactable.Building
{
    [Override]
    public partial class BPC_TownCenter_C
    {
        [Override]
        public override void ReceiveBeginPlay()
        {
            base.ReceiveBeginPlay();

            TokenSource = new CancellationTokenSource();

            OnBeginPlay();
        }

        [Override]
        public override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
        {
            base.ReceiveEndPlay(EndPlayReason);

            TokenSource?.Cancel();
        }

        private async void OnBeginPlay()
        {
            while (!TokenSource.IsCancellationRequested)
            {
                await Task.Delay(1000);

                TokenSource.Cancel();

                var PlayerController = UGameplayStatics.GetPlayerController(this, 0);

                var SweepHitResult = new FHitResult();

                PlayerController.K2_GetPawn().K2_SetActorLocation(
                    K2_GetActorLocation(),
                    false,
                    ref SweepHitResult,
                    false);
            }
        }

        private CancellationTokenSource TokenSource;
    }
}