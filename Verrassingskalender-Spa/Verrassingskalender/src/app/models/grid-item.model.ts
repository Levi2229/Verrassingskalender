export interface GridItem {
  isRevealed: boolean;
  content: GridContent;
}

export enum GridContent {
  noPrize = 'noPrize',
  consolationPrize = 'consolationPrize',
  grandPrize = 'grandPrize',
}
