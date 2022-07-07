import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { CellContent } from '../models/cell-enum.model';
import { ScratchGrid } from '../models/scratch-grid.model';

@Injectable({
  providedIn: 'root',
})
export class GridDataService {
  private readonly baseUrl = 'https:/localhost:7075';

  constructor(private readonly httpClient: HttpClient) {}

  getGrid(): Observable<ScratchGrid> {
    return this.httpClient.get<ScratchGrid>(`${this.baseUrl}/api/grid`);
  }

  scratchCell(cellId: number) {
    return this.httpClient.post<CellContent>(
      `${this.baseUrl}/api/grid/scratch`,
      {
        id: cellId,
      }
    );
  }
}
