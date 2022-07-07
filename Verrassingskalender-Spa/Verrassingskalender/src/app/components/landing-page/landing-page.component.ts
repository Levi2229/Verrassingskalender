import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { resources } from 'src/app/resources/resources-nl.model';
import { AppStateService } from '../../services/app-state.service';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.scss'],
})
export class LandingPageComponent implements OnInit {
  public nameForm: FormGroup;
  public resources = resources;

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly appStateService: AppStateService,
    private readonly router: Router
  ) {
    this.nameForm = this.formBuilder.group({
      name: ['', Validators.required],
    });
  }

  ngOnInit(): void {}

  tryNavigateToScratchGrid() {
    this.nameForm.controls.name.markAsDirty();
    if (this.nameForm.valid) {
      this.appStateService.setName(this.nameForm.controls.name.value);
      this.router.navigateByUrl('./scratchgrid');
    }
  }
}
