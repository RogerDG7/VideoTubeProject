import { Component, OnInit } from '@angular/core';
import { Video } from 'src/app/Models/Video';
import { ApiVideoService } from 'src/app/Services/api-video.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  lstVideos: Array<Video> = [];

  constructor(private apiVideo : ApiVideoService) { }

  ngOnInit(): void {
    this.apiVideo.GetRandomVideo().subscribe(response => {
      this.lstVideos = response.objectResponse;
    });
  }

}
