/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Component, Input } from '@angular/core';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CatsGroupedComponent } from './cats-grouped.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { of } from 'rxjs/internal/observable/of';
import { CatService } from '../../../shared/services';
import { MockCatService } from '../../../shared/services/cat.service.mock';
import { IGrouped } from 'src/app/shared/models';
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
  const groups = [
    { gender: "Male", pets: ["Garfield","Jim","Max","Tom"] } as IGrouped,
    { gender:"Female",pets:["Garfield","Tabby","Simba"]} as IGrouped
  ]
  let catService: CatService;
  let component: CatsGroupedComponent;
  let fixture: ComponentFixture<CatsGroupedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [ CatsGroupedComponent, SpinnerComponent ],
      providers: [
        { provide: CatService, useClass: MockCatService }
      ]
    })
    .compileComponents();
    catService = TestBed.get(CatService);
    spyOn(catService, 'getCatsGrouped').and.returnValue(of(groups));
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CatsGroupedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  describe('ngOnInit', () => { 

    beforeEach(() => {
      spyOn(component, 'getItems');
      component.ngOnInit();
    });

    it('should call "getItems" & "getCatsGrouped"', () => {  
      expect(component.getItems).toHaveBeenCalled();
      expect(catService.getCatsGrouped).toHaveBeenCalled();     
    });

    it('should have "2" items', () => {  
      expect(component.groups.length).toBe(2);
    });

    it('should first item gender be "Male" and have "4" pets', () => {  
      expect(component.groups[0].gender).toEqual('Male');
      expect(component.groups[0].pets.length).toBe(4);
    });

    it('should "Male" pets be in order "Garfield","Jim","Max","Tom"', () => {  
      expect(component.groups[0].pets[0]).toEqual('Garfield');
      expect(component.groups[0].pets[1]).toEqual('Jim');
      expect(component.groups[0].pets[2]).toEqual('Max');
      expect(component.groups[0].pets[3]).toEqual('Tom');
    });

    it('should second item gender be "Female" and have "3" pets', () => {  
      expect(component.groups[1].gender).toEqual('Female');
      expect(component.groups[1].pets.length).toBe(3);
    });

    it('should "Female" pets be in order "Garfield","Tabby","Simba"', () => {
      expect(component.groups[1].pets[0]).toEqual('Garfield');
      expect(component.groups[1].pets[1]).toEqual('Tabby');
      expect(component.groups[1].pets[2]).toEqual('Simba');
    });

  });

});
