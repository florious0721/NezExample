using Nez;

class NewGame: Core {
    public static int Main(string[] args) {
        using (NewGame g = new NewGame()) g.Run();
        return 0;
    }

    protected override void Initialize() {
        base.Initialize();
        Scene = new MainScene();
    }
}
