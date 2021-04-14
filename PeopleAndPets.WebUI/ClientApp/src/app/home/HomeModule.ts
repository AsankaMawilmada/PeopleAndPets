import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CatsGroupedComponent } from './components/cats-grouped/cats-grouped.component';
import { HomeComponent } from './home.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module'
@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild([{ path: '', component: HomeComponent, pathMatch: 'full' }])
  ],
  declarations: [
    CatsGroupedComponent,
    HomeComponent
  ],
  providers: [ ],
  exports:[

  ]
})
export class HomeModule { }
