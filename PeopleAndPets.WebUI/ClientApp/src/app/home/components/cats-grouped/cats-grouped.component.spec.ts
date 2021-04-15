/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Component, Input } from '@angular/core';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CatsGroupedComponent } from './cats-grouped.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { of } from 'rxjs/internal/observable/of';
import { CatService } from '../../../shared/services';

@Component({
  selector: '[spinner]',
  template: ''
})
class SpinnerComponent {
  @Input('busy')
  busy: boolean = false;
  constructor() { }
}

describe('CatsGroupedComponent', () => {
  const mockCatService = ({
    getCatsGrouped: () => {
      return of(
        JSON.parse(
          '[{"gender":"Male","pets":["Garfield","Jim","Max","Tom"]},{"gender":"Female","pets":["Garfield","Tabby","Simba"]}]'
        )
      );
    },
  } as unknown) as CatService;


  let component: CatsGroupedComponent;
  let fixture: ComponentFixture<CatsGroupedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [ CatsGroupedComponent, SpinnerComponent ],
      providers: [
        { provide: CatService, useValue: mockCatService }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CatsGroupedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should ngOnInit call "getItems"', () => {
    spyOn(component, 'getItems');
    component.ngOnInit();

    expect(component.busy).toBeFalsy();
    expect(component.getItems).toHaveBeenCalled();
    expect(component.groups.length).toBe(2);
  });

  it('should ngOnInit call "getItems"', () => {

  });

});
