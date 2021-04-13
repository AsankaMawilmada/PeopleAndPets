import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule} from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { SharedModule } from './shared/shared.module';
import { NavMenuComponent } from './shared/components/nav-menu/nav-menu.component';

@NgModule({
  imports: [
    SharedModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([{ path: '', component: HomeComponent, pathMatch: 'full' }])    
  ],
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
