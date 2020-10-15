import { AirDateService } from './../shared/air-date.service';
import { AnimeTypeService } from './../shared/anime-type.service';
import { AnimeService } from './../shared/anime.service';
import { StudioService } from './../shared/studio.service';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-anime',
  templateUrl: './anime.component.html',
  styleUrls: ['./anime.component.css']
})
export class AnimeComponent implements OnInit {

  AnimeForms : FormArray = this.fb.array([]);
  studioList : [];
  animetypeList : [];
  airdateList : [];
  constructor(private fb: FormBuilder,
      private studioService : StudioService,
      private animetypeService : AnimeTypeService,
      private airdateService : AirDateService,
      private animeService : AnimeService
    ) { }

  ngOnInit(): void {

    this.airdateService.getAirDateList().subscribe(
      res => this.airdateList = res as []
    );

    this.animetypeService.getAnimeTypeList().subscribe(
      res => this.animetypeList = res as []
    );

    this.studioService.getStudioList().subscribe(
      res => this.studioList = res as []
    );

    this.addAnimeForm();
  }

  addAnimeForm(){
    this.AnimeForms.push(this.fb.group({
      AnimeID :[0, Validators.required],
      StudioId :[0, Validators.required],
      AnimeName : ['', Validators.required],
      EpsodesTotal : ['', Validators.required],
      AnimeTypeId : [0, Validators.required],
      AirDateId : [0, Validators.required],
      ViewCount : [''],
      Status : ['',Validators.required],
      CommentId : [0],
      AnimeImg : [''],
      AnimeSource : ['']
    }));
  }

  recordSubmit(fg:FormGroup){
    this.animeService.postAnime(fg.value).subscribe(
      (res : any) =>{
        

      }
    );
  }
  
}
