namespace StatePatternMusicPlayer
{
    interface IPlayerState
    {
        void Play(PlayerContext context);
        void Pause(PlayerContext context);
        void Stop(PlayerContext context);
        void Next(PlayerContext context);
        string GetStateName();
    }
}