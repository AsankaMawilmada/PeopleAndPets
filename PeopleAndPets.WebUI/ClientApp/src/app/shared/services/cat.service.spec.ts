/* tslint:disable:no-unused-variable */
import { TestBed, inject } from "@angular/core/testing";
import { CatService } from "./cat.service";
import { HttpClientTestingModule } from "@angular/common/http/testing";
import { ApiService } from "./api.service";
import { IGrouped } from "../models";
import { of } from "rxjs/internal/observable/of";

describe("Service: Cat", () => {
  const mockApiService = ({
    get: () => {
      return of(
        JSON.parse(
          '[{"gender":"Male","pets":["Garfield","Jim","Max","Tom"]},{"gender":"Female","pets":["Garfield","Tabby","Simba"]}]'
        )
      );
    },
  } as unknown) as ApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [CatService],
    });
  });

  it("should ...", inject([CatService], (service: CatService) => {
    expect(service).toBeTruthy();
  }));

  describe("getCatsGrouped", () => {
    const catService = new CatService(mockApiService);

    it("should return array with 2 items", () => {
      catService.getCatsGrouped().subscribe((groups: IGrouped[]) => {
        expect(groups.length).toBe(2);
      });
    });

    it('should return first item with gender "Male" and 4 pets', () => {
      catService.getCatsGrouped().subscribe((groups: IGrouped[]) => {
        expect(groups[0].gender).toBeDefined();
        expect(groups[0].gender).toEqual("Male");
        expect(groups[0].pets).toBeDefined();
        expect(groups[0].pets.length).toBe(4);
      });
    });

    it('should return first item with pets name in defined order', () => {
      catService.getCatsGrouped().subscribe((groups: IGrouped[]) => {
        expect(groups[0].pets[0]).toEqual("Garfield");
        expect(groups[0].pets[1]).toEqual("Jim");
        expect(groups[0].pets[2]).toEqual("Max");
        expect(groups[0].pets[3]).toEqual("Tom");
      });
    });

    it('should return second item with gender "Female" and 3 pets', () => {
      catService.getCatsGrouped().subscribe((groups: IGrouped[]) => {
        expect(groups[1].gender).toBeDefined();
        expect(groups[1].gender).toEqual("Female");
        expect(groups[1].pets).toBeDefined();
        expect(groups[1].pets.length).toBe(3);
      });
    });

    it('should return second item with pets name in defined order', () => {
      catService.getCatsGrouped().subscribe((groups: IGrouped[]) => {
        expect(groups[1].pets[0]).toEqual("Garfield");
        expect(groups[1].pets[1]).toEqual("Tabby");
        expect(groups[1].pets[2]).toEqual("Simba");
      });
    });
  });
});
