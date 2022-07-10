import { GridDataService } from '../../../services/grid-data.service';
import { ScratchGrid } from '../../../models/scratch-grid.model';
import { AppStateService } from '../../../services/app-state.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CellContent } from 'src/app/models/cell-enum.model';
import { PrizeRevealDialogComponent } from '../prize-reveal-dialog/prize-reveal-dialog.component';
import { Router } from '@angular/router';
import { Cell } from 'src/app/models/cell.model';
import { finalize, Subscription } from 'node_modules/rxjs';

@Component({
  selector: 'app-grid-container',
  templateUrl: './grid-container.component.html',
  styleUrls: ['./grid-container.component.scss'],
})
export class GridContainerComponent implements OnInit, OnDestroy {
  grid: ScratchGrid | undefined;
  playerName: string | undefined;
  hasLoaded: boolean | undefined;
  subscription: Subscription | undefined;

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
      return;
    }

    var gridFromState = this.appStateService.getGrid();
    if (gridFromState === undefined) {
      this.subscription = this.gridDataService
        .getGrid()
        .pipe(finalize(() => (this.hasLoaded = true)))
        .subscribe((result) => {
          this.grid = result;
          this.appStateService.setGrid(result);
        });
    } else {
      this.grid = gridFromState;
      this.hasLoaded = true;
    }
  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }

  scratchCellWithId(cellId: number) {
    if (!this.playerName) {
      return;
    }
    this.gridDataService
      .scratchCell(cellId, this.playerName)
      .subscribe((result) => {
        const cellAtPosition = this.grid?.cells.find((og) => og.id === cellId);
        if (!cellAtPosition) {
          return;
        }
        cellAtPosition.cellContent = result;
        this.openDialog('2500', '2500', result);
      });
  }

  public getClassForCell(cell: Cell): string {
    switch (cell.cellContent) {
      case CellContent.consolationPrize:
        return 'consolation-prize';
      case CellContent.grandPrize:
        return 'grand-prize';
      case CellContent.noPrize:
        return 'no-prize';
    }
  }

  public get cells() {
    if (!this.grid || !this.grid.cells) {
      return;
    }
    return this.grid.cells;
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
