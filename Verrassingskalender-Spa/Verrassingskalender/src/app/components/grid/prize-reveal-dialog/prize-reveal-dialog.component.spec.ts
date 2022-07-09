import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrizeRevealDialogComponent } from './prize-reveal-dialog.component';

describe('PrizeRevealDialogComponent', () => {
  let component: PrizeRevealDialogComponent;
  let fixture: ComponentFixture<PrizeRevealDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrizeRevealDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrizeRevealDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
