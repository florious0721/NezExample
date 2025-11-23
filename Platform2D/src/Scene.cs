using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.Textures;

public class MainScene: Scene {
    public override void Initialize() {
        base.Initialize();

        Texture2D avatarSprite = Content.Load<Texture2D>("Avatar.jpg");
        Texture2D idleSprites = Content.Load<Texture2D>("Player/Idle.png");
        Sprite idleSprite = new(idleSprites, new Rectangle(16, 18, 15, 26));

        var player = CreateEntity("Avatar");
        player.Scale = new Vector2(1.5f, 1.5f);

        player.AddComponent(new SpriteRenderer(idleSprite));
        player.AddComponent(new BoxCollider());

        var rb = new ArcadeRigidbody();
        player.AddComponent(rb);
        rb.Elasticity = 0f;
        player.AddComponent(new Move());

        var camera = new Camera();
        camera.SetZoom(.6f);
        player.AddComponent(camera);
        Camera = camera;

        Texture2D platSprite = Content.Load<Texture2D>("StonePlatform.png");

        var platform = CreateEntity("Platform");
        platform.Position = new Vector2(0, 500);

        var platSr = new TiledSpriteRenderer(platSprite);
        platform.AddComponent(platSr);
        platSr.Width = 2400;
        platSr.Height = 24;

        platform.AddComponent(new BoxCollider());
    }
}

public class Move: Component, IUpdatable {
    ArcadeRigidbody? rb;

    public override void Initialize() {
        rb = Entity.GetComponent<ArcadeRigidbody>();
    }
    public void Update() {
        float veloX = 0f;
        float veloY = 0f;
        if (Input.IsKeyDown(Keys.D)) veloX += 100f;
        if (Input.IsKeyDown(Keys.A)) veloX -= 100f;
        if (Input.IsKeyPressed(Keys.Space)) veloY = -200f;
        else veloY = rb.Velocity.Y;
        rb.Velocity = new Vector2(veloX, veloY);
    }
}
