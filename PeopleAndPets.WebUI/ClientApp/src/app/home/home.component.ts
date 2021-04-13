import { Component, OnInit, OnDestroy } from '@angular/core';
import { SubscriptionLike } from 'rxjs';
import { CatService } from '../shared/services/cat.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit, OnDestroy  {
  busy: boolean = false;
  public data: any;
  subscriber$: SubscriptionLike;

  constructor(private catService: CatService) {

  }

  ngOnInit() {
    this.getItems();
  }

  getItems() {
    this.subscriber$ = this.catService.getCatsGrouped().subscribe(data => {
      this.busy = false;
      this.data = data;
    })
  }

  ngOnDestroy() {
    if (this.subscriber$) {
      this.subscriber$.unsubscribe();
    }
  }  
}

