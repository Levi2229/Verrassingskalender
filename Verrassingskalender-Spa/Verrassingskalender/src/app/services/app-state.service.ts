import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AppStateService {
  private name: string | undefined;

  public setName(name: string) {
    this.name = name;
  }

  public getName() {
    return this.name;
  }

  constructor() {}
}
