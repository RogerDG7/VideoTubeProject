import { Component, Input, OnInit } from '@angular/core';
import { Video } from 'src/app/Models/Video';

@Component({
  selector: 'app-video-card',
  templateUrl: './video-card.component.html',
  styleUrls: ['./video-card.component.css']
})
export class VideoCardComponent implements OnInit {

  @Input()
  videoResult! : Video

  constructor() { }

  ngOnInit(): void {
  }

}
