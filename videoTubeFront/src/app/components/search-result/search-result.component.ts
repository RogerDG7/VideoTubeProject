import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiResponseVideoPag } from 'src/app/Models/ApiResponseVideoPag';
import { Pagination } from 'src/app/Models/Pagination';
import { Video } from 'src/app/Models/Video';
import { ApiVideoService } from 'src/app/Services/api-video.service';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.css']
})
export class SearchResultComponent implements OnInit {

  response! : ApiResponseVideoPag;
  lstVideos: Array<Video> = [];
  actualKeyWord!: string;

  constructor(private apiVideoService : ApiVideoService, private route: ActivatedRoute) {
    this.route.params.subscribe((param) => {
      this.actualKeyWord = param['keyword'] 
      this.searchResult(param['keyword'],1);
    });
  }

  handlePage(e: PageEvent){
    this.searchResult(this.actualKeyWord,e.pageIndex+1);
  }

  ngOnInit(): void {
  }

  searchResult(keyWord: string,currentPage: number) {
    const pagination: Pagination = {
      isPaginable: true,
      itemsPerPage: 2,
      currentPage: currentPage
    }
    const searchVideo = {
      nameVideoOrArtist: keyWord,
      pagination: pagination
    }

    this.apiVideoService.GetAllVideosFilter(searchVideo).subscribe(data => {
      this.response = data;
      this.lstVideos = data.objectResponse.videoModels;
    }
    );
  }

}
