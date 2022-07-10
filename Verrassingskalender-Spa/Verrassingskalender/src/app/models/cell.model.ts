import { CellContent } from './cell-enum.model';

export interface Cell {
  id: number;
  cellContent: CellContent;
  x?: number | undefined;
  y?: number | undefined;
}
