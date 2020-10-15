import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AnimeTypeService {

  constructor(private http: HttpClient) { }

  getAnimeTypeList(){
    return this.http.get(environment.apiBaseURL + '/AnimeTypes');

  }

}


