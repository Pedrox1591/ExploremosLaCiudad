using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
namespace YoutubePlayer
{
    public class videoControl : MonoBehaviour
    {
        // Start is called before the first frame update
        public YoutubePlayer a;
        VideoPlayer videoPlayer;
        public Button btn_play;
        public Button btn_pause;
        public Button btn_reset;
        public AudioSource Camera_audio;
        public Animator animatorController;
        private void Awake()
        {
            Prepare();
            Camera_audio.mute= true;
            btn_play.interactable = false;
            btn_pause.interactable = false;
            btn_reset.interactable = false;
            videoPlayer = a.GetComponent<VideoPlayer>();
            videoPlayer.prepareCompleted += VideoPlayerPreparedCompleted;
        }
        void VideoPlayerPreparedCompleted(VideoPlayer source)
        {
            btn_play.interactable = source.isPrepared;
            btn_pause.interactable = source.isPrepared;
            btn_reset.interactable = source.isPrepared;
        }
        public async void Prepare()
        {
            Debug.Log("Se esta cargando el video");
            try
            {
                await a.PrepareVideoAsync();
                Debug.Log("video cargado correctamente");
                
            }
            catch
            {
                Debug.Log("video no cargado correctamente");
            }
        }
        public void PlayVideo()
        {
            videoPlayer.Play();
            Debug.Log("se le dio a play");
        }
        public void PauseVideo()
        {
            videoPlayer.Pause();
        }
        public void resetVideo()
        {
            videoPlayer.Stop();
            videoPlayer.Play();
        }
        void OnDestroy()
        {
            videoPlayer.prepareCompleted -= VideoPlayerPreparedCompleted;
        }
        public void animacion()
        {
            animatorController.Play("Mover_zona_video");
        }
    }

}

