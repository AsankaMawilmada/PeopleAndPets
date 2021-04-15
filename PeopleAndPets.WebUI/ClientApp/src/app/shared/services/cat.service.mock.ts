import { Observable, of } from "rxjs";
import { IGrouped } from "../models";
import { CatService } from "./cat.service";
export class MockCatService extends CatService {
  groups: IGrouped[] = [];

  getCatsGrouped(): Observable<IGrouped[]> {
    return of(this.groups)
  }
}