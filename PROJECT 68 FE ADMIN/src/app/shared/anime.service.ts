import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AnimeService {

  constructor(private http:HttpClient) { }

  postAnime(formData){
    return this.http.post(environment.apiBaseURL+'/Animes', formData);
  }

  
 
   putAnime(formData){
     return this.http.put(environment.apiBaseURL+'/Animes/' + formData.AnimeID ,formData);
    }
 
    deleteAnime(id){
     return this.http.delete(environment.apiBaseURL+'/Animes/' + id );
    }
 
 
   getAnimeList(){
     return this.http.get(environment.apiBaseURL+'/Animes');
   }
  
}
