namespace StatePatternMusicPlayer
{
    class PausedState : IPlayerState
    {
        public void Play(PlayerContext context) => context.SetState(new PlayingState());
        public void Pause(PlayerContext context) { }
        public void Stop(PlayerContext context) => context.SetState(new StoppedState());
        public void Next(PlayerContext context)
        {
            context.CurrentTrackIndex = (context.CurrentTrackIndex + 1) % context.Playlist.Length;
        }
        public string GetStateName() => "Paused";
    }
}