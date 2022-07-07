import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ScratchGrid } from '../models/scratch-grid.model';

@Injectable({
  providedIn: 'root',
})
export class GridDataService {
  constructor(private readonly httpClient: HttpClient) {}

  getGrid(): Observable<ScratchGrid> {
    return this.httpClient.get('someurl/api/grid');
  }
}
