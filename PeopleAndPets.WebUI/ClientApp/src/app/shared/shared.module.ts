import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpinnerComponent } from './directives';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';

@NgModule({
  imports: [
    CommonModule,

  ],
  declarations: [
    SpinnerComponent,
    NavMenuComponent
  ],
  providers: [ ],
  exports:[
    SpinnerComponent,
    NavMenuComponent
  ]
})
export class SharedModule { }
