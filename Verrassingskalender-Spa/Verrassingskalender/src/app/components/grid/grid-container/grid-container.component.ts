import { GridDataService } from '../../../services/grid-data.service';
import { ScratchGrid } from '../../../models/scratch-grid.model';
import { AppStateService } from '../../../services/app-state.service';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-grid-container',
  templateUrl: './grid-container.component.html',
  styleUrls: ['./grid-container.component.scss'],
})
export class GridContainerComponent implements OnInit {
  originalGrid: ScratchGrid | undefined;

  playerName: string | undefined;

  constructor(
    private readonly gridDataService: GridDataService,
    private readonly appStateService: AppStateService
  ) {}

  ngOnInit(): void {
    this.playerName = this.appStateService.getName();

    this.gridDataService.getGrid().subscribe((result) => {
      this.originalGrid = result;
    });
  }

  scratchCellWithId(cellId: number) {
    this.gridDataService.scratchCell(cellId).subscribe((result) => {
      const cellAtPosition = this.originalGrid?.cells.find(
        (og) => og.id === cellId
      );
      if (!cellAtPosition) {
        return;
      }
      cellAtPosition.cellContent = result;
    });
  }

  get cells() {
    if (!this.originalGrid || !this.originalGrid.cells) {
      return;
    }
    return this.originalGrid.cells;
  }
}
