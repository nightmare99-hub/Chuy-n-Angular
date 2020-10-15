import { NgModule} from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

import {HomeComponent} from './Components/Pages/Home/home.component';
import {CateComponent} from './Components/Pages/Cate/cate.component';
import {DetailComponent} from './Components/Pages/Detail/detail.component';

const routesConfig : Routes =[
    {path: 'cate', component: CateComponent },  
    {path: 'detail', component: DetailComponent},  
    {path: '**', component: HomeComponent}
]

@NgModule({
    declarations:[
        HomeComponent,
        CateComponent,
        DetailComponent
    ],

    imports :[
        RouterModule.forRoot(routesConfig),
        CommonModule,

    ],
    exports: [ RouterModule ]
})

export class ApproutingModule {}
