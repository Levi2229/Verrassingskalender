import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { CellContent } from 'src/app/models/cell-enum.model';

@Component({
  selector: 'app-prize-reveal-dialog',
  templateUrl: './prize-reveal-dialog.component.html',
})
export class PrizeRevealDialogComponent {
  public cellContentEnum = CellContent;

  constructor(
    public dialogRef: MatDialogRef<PrizeRevealDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public prize: CellContent,
    private readonly router: Router
  ) {}

  /* Uitbreiding voor echte situatie: Enums kunnen veranderen, dus mappen op de integer value van enum is niet handig.
   * Hiervoor zou ik een andere mapping zoeken in een echte opdracht.
   */
  get readableStringFromCellContent(): string {
    switch (this.prize) {
      case CellContent.consolationPrize:
        return 'Gefeliciteerd, u heeft een prijs van €100 gewonnen!';
      case CellContent.grandPrize:
        return 'Gefeliciteerd, u heeft de hoofdprijs van €25000 gewonnen!';
      case CellContent.noPrize:
        return 'Helaas, u heeft geen prijs gewonnen.';
      default:
        return 'Er is iets misgegaan.';
    }
  }

  public navigateToLandingPage(): void {
    this.dialogRef.close();
    this.router.navigateByUrl('');
  }
}
