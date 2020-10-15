import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StudioService {

  constructor(private http: HttpClient) { }

  getStudioList(){
    return this.http.get(environment.apiBaseURL + '/Studios');

  }
}
