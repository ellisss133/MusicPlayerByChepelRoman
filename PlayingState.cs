namespace StatePatternMusicPlayer
{
    class PlayingState : IPlayerState
    {
        public void Play(PlayerContext context) { }
        public void Pause(PlayerContext context) => context.SetState(new PausedState());
        public void Stop(PlayerContext context) => context.SetState(new StoppedState());
        public void Next(PlayerContext context)
        {
            context.CurrentTrackIndex = (context.CurrentTrackIndex + 1) % context.Playlist.Length;
        }
        public string GetStateName() => "Playing";
    }
}