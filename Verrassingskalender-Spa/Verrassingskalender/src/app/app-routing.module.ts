import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { GridContainerComponent } from './components/grid/grid-container/grid-container.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//TODO for technical improvement/clarity: router names as constants.
const routes: Routes = [
  {
    path: '',
    component: LandingPageComponent,
  },
  {
    path: 'scratchgrid',
    component: GridContainerComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
