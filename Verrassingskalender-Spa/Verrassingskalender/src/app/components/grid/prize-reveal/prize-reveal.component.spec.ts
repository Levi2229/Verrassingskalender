import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrizeRevealComponent } from './prize-reveal.component';

describe('PrizeRevealComponent', () => {
  let component: PrizeRevealComponent;
  let fixture: ComponentFixture<PrizeRevealComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrizeRevealComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrizeRevealComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
