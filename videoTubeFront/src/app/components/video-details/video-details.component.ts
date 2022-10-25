import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Users } from 'src/app/Models/Users';
import { Video } from 'src/app/Models/Video';
import { ApiVideoService } from 'src/app/Services/api-video.service';

@Component({
  selector: 'app-video-details',
  templateUrl: './video-details.component.html',
  styleUrls: ['./video-details.component.css']
})
export class VideoDetailsComponent implements OnInit {

  videoId: string;
  videoModel!: Video;
  likeCount: number = 0;
  dislikeCount: number = 0;
  lstVideos: Array<Video> = [];

  constructor(private activeRoute: ActivatedRoute,private apiVideo : ApiVideoService) { 
    this.videoId = this.activeRoute.snapshot.params['videoId'];
    this.apiVideo.GetByIdVideo(this.videoId).subscribe(response => {
      this.videoModel = <Video>response.objectResponse;
      this.likeCount = this.videoModel.likes;
      this.dislikeCount = this.videoModel.dislikes;
    });
    
  }

  likeVideo() {
    const LikeModel = {
      "videoID": this.videoId,//quemado por ahora no hay login
      "IsLike": true 
    }
    this.apiVideo.LikeDislikeVideo(LikeModel).subscribe(data => {
      this.likeCount = data.objectResponse;
    })
  }

  disLikeVideo() {
    const LikeModel = {
      "videoID": this.videoId, //quemado por ahora no hay login
      "IsLike": false 
    }
    this.apiVideo.LikeDislikeVideo(LikeModel).subscribe(data => {
      this.dislikeCount = data.objectResponse;
    })
  }

  ngOnInit(): void {
    this.apiVideo.GetRandomVideo().subscribe(response => {
      this.lstVideos = response.objectResponse;
    });
  }

}
