import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Models/ApiResponse'
import { ApiResponseVideoPag } from '../Models/ApiResponseVideoPag';
 
const httpOption = {
  headers: new HttpHeaders({
    'Contend-Type' : 'application/json'
  }),
};

@Injectable({
  providedIn: 'root'
})

export class ApiVideoService {

  url: string = 'https://localhost:7243/api/Video/';

  constructor(private _http: HttpClient) { }

  GetRandomVideo(): Observable<ApiResponse>{
    return this._http.get<ApiResponse>(`${this.url}GetVideosRandom`);
  }

  GetByIdVideo(id:string): Observable<ApiResponse>{
    return this._http.get<ApiResponse>(`${this.url}GetByIdVideo?id=${id}`);
  }

  LikeDislikeVideo(model: any): Observable<ApiResponse>{
    return this._http.post<ApiResponse>(this.url + 'LikeOrDislikeVideo',model,httpOption);
  }

  GetAllVideosFilter(model: any): Observable<ApiResponseVideoPag>{
    return this._http.post<ApiResponseVideoPag>(this.url + 'GetAllVideosFilter',model,httpOption);
  }
  
}
