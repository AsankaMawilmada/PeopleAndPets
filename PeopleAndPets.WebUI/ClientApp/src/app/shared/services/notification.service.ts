import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root",
})
export class NotificationService {
  constructor() {}

  error(message: string) {
    alert(`Error : ${message}`);
  }

  success(message: string) {
    alert(`Success : ${message}`);
  }
}
