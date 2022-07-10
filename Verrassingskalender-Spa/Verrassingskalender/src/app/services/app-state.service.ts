import { ScratchGrid } from '../models/scratch-grid.model';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AppStateService {
  private name: string | undefined;
  private grid: ScratchGrid | undefined;

  public setName(name: string): void {
    this.name = name;
  }

  public getName(): string | undefined {
    return this.name;
  }

  public setGrid(grid: ScratchGrid) {
    this.grid = grid;
  }

  public getGrid(): ScratchGrid | undefined {
    return this.grid;
  }

  constructor() {}
}
