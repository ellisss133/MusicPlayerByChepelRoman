namespace StatePatternMusicPlayer
{
    class StoppedState : IPlayerState
    {
        public void Play(PlayerContext context) => context.SetState(new PlayingState());
        public void Pause(PlayerContext context) { }
        public void Stop(PlayerContext context) { }
        public void Next(PlayerContext context)
        {
            context.CurrentTrackIndex = (context.CurrentTrackIndex + 1) % context.Playlist.Length;
        }
        public string GetStateName() => "Stopped";
    }
}