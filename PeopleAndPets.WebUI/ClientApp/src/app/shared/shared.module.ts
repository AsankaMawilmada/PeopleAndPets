import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpinnerComponent } from './directives';
@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    SpinnerComponent
  ],
  providers: [ ],
  exports:[
    SpinnerComponent
  ]
})
export class SharedModule { }