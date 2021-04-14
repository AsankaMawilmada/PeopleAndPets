import { Component, OnDestroy, OnInit } from '@angular/core';
import { SubscriptionLike } from 'rxjs';
import { IGrouped } from '../../../shared/models';
import { CatService } from '../../../shared/services';
@Component({
  selector: 'app-cats-grouped',
  templateUrl: './cats-grouped.component.html',
  styleUrls: ['./cats-grouped.component.css']
})
export class CatsGroupedComponent implements OnInit, OnDestroy  {
  busy: boolean = false;
  groups: IGrouped[] = [];
  subscriber$: SubscriptionLike;

  constructor(private catService: CatService) {

  }

  ngOnInit() {
    this.getItems();
  }

  getItems() {
    this.busy = true;
    this.subscriber$ = this.catService.getCatsGrouped().subscribe((groups: IGrouped[]) => {
      this.busy = false;
      this.groups = groups;
    })
  }

  ngOnDestroy() {
    if (this.subscriber$) {
      this.subscriber$.unsubscribe();
    }
  }
}

