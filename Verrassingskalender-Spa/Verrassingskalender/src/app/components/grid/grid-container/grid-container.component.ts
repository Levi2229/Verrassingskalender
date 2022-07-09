import { GridDataService } from '../../../services/grid-data.service';
import { ScratchGrid } from '../../../models/scratch-grid.model';
import { AppStateService } from '../../../services/app-state.service';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CellContent } from 'src/app/models/cell-enum.model';
import { PrizeRevealDialogComponent } from '../prize-reveal-dialog/prize-reveal-dialog.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-grid-container',
  templateUrl: './grid-container.component.html',
  styleUrls: ['./grid-container.component.scss'],
})
export class GridContainerComponent implements OnInit {
  originalGrid: ScratchGrid | undefined;
  playerName: string | undefined;
  hasLoaded: boolean | undefined;

  constructor(
    private readonly dialog: MatDialog,
    private readonly router: Router,
    private readonly gridDataService: GridDataService,
    private readonly appStateService: AppStateService
  ) {}

  ngOnInit(): void {
    this.playerName = this.appStateService.getName();

    if (!this.playerName) {
      this.router.navigateByUrl('');
    }

    this.gridDataService.getGrid().subscribe((result) => {
      this.originalGrid = result;
      this.hasLoaded = true;
    });
  }

  scratchCellWithId(cellId: number) {
    if (!this.playerName) {
      return;
    }
    this.gridDataService
      .scratchCell(cellId, this.playerName)
      .subscribe((result) => {
        const cellAtPosition = this.originalGrid?.cells.find(
          (og) => og.id === cellId
        );
        if (!cellAtPosition) {
          return;
        }
        cellAtPosition.cellContent = result;
        this.openDialog('2500', '2500', result);
      });
  }

  public get cells() {
    if (!this.originalGrid || !this.originalGrid.cells) {
      return;
    }
    return this.originalGrid.cells;
  }

  private openDialog(
    enterAnimationDuration: string,
    exitAnimationDuration: string,
    prize: CellContent
  ): void {
    this.dialog.open(PrizeRevealDialogComponent, {
      width: '500px',
      data: prize,
      enterAnimationDuration,
      exitAnimationDuration,
    } as any);
  }
}
