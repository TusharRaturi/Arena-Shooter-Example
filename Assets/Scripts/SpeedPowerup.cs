public class SpeedPowerup : Powerup
{
    public float speedMultiplier = 2.0f;
    private float originalSpeed;

    protected override void OnApply(Player player)
    {
        originalSpeed = player.Speed;
        player.Speed = player.Speed * speedMultiplier;
    }

    protected override void OnRemove(Player player)
    {
        player.Speed = originalSpeed;
    }
}
