import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Models/ApiResponse'
 
const httpOption = {
  headers: new HttpHeaders({
    'Contend-Type' : 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class ApiCommentService {

  url: string = 'https://localhost:7243/api/Comment/';

  constructor(private _http: HttpClient) { }

  PostCommentVideo(comment: any): Observable<ApiResponse>{
    return this._http.post<ApiResponse>(this.url + 'CreateComment',comment,httpOption);
  }

  GetComments(idVideo: string): Observable<ApiResponse>{
    return this._http.get<ApiResponse>(`${this.url}GetCommentsVideo?idVideo=${idVideo}`);
  }

}
