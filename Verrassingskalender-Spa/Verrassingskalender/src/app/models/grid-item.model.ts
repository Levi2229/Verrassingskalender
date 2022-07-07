export interface GridItem {
  content: GridContent;
}

export enum GridContent {
  unrevealed = 'unrevealed',
  empty = 'empty',
  consolationPrize = 'consolationPrize',
  grandPrize = 'grandPrize',
}
