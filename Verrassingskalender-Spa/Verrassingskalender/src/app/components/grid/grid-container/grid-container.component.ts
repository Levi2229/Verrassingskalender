import { GridDataService } from '../../../services/grid-data.service';
import { ScratchGrid } from '../../../models/scratch-grid.model';
import { AppStateService } from '../../../services/app-state.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-grid-container',
  templateUrl: './grid-container.component.html',
  styleUrls: ['./grid-container.component.scss'],
})
export class GridContainerComponent implements OnInit {
  scratchGrid: ScratchGrid | undefined;
  playerName: string | undefined;

  constructor(
    private readonly gridDataService: GridDataService,
    private readonly appStateService: AppStateService
  ) {}

  ngOnInit(): void {
    this.playerName = this.appStateService.getName();

    this.gridDataService
      .getGrid()
      .subscribe((result) => (this.scratchGrid = result));
  }
}
