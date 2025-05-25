using System.IO;
using NAudio.Wave;
using StatePatternMusicPlayer;

class PlayerContext
{
    private IPlayerState _state;
    public string[] Playlist = Directory.GetFiles("Tracks", "*.mp3");
    public int CurrentTrackIndex = 0;

    private IWavePlayer waveOut;
    private AudioFileReader audioFile;

    private bool isPaused = false;

    public PlayerContext()
    {
        _state = new StoppedState();
    }

    public void SetState(IPlayerState state)
    {
        _state = state;
    }

    public void Play()
    {
        if (isPaused && waveOut != null)
        {
            waveOut.Play();
            isPaused = false;
        }
        else
        {
            StopPlayback();
            string track = Playlist[CurrentTrackIndex];
            audioFile = new AudioFileReader(track);
            waveOut = new WaveOutEvent();
            waveOut.Init(audioFile);
            waveOut.Play();
        }

        _state.Play(this);
    }

    public void Pause()
    {
        if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
        {
            waveOut.Pause();
            isPaused = true;
        }
        _state.Pause(this);
    }

    public void Stop()
    {
        StopPlayback();
        isPaused = false;
        _state.Stop(this);
    }

    public void Next()
    {
        StopPlayback();
        isPaused = false;

        CurrentTrackIndex = (CurrentTrackIndex + 1) % Playlist.Length;
        _state.Next(this);
        Play();
    }

    public string GetStateName() => _state.GetStateName();
    public string GetCurrentTrack() => Path.GetFileName(Playlist[CurrentTrackIndex]);

    private void StopPlayback()
    {
        waveOut?.Stop();
        audioFile?.Dispose();
        waveOut?.Dispose();
        audioFile = null;
        waveOut = null;
    }
}
