public class ShootingSpeedPowerup : Powerup
{
    public float shootingSpeedMultiplier = 2.0f;
    private float originalShootingSpeed;

    protected override void OnApply(Player player)
    {
        originalShootingSpeed = player.ShootingSpeed;
        player.ShootingSpeed = player.ShootingSpeed * shootingSpeedMultiplier;
    }

    protected override void OnRemove(Player player)
    {
        player.ShootingSpeed = originalShootingSpeed;
    }
}