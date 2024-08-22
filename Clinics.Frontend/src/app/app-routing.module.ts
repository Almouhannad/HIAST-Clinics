import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { RoleGuard } from './services/authentication/guards/role-guard';
import { Roles } from './classes/Authentication/roles';
import { ForbiddenComponent } from './components/errors/forbidden/forbidden.component';
import { NotFoundComponent } from './components/errors/not-found/not-found.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },

  {
    path: 'home',
    component: HomeComponent,
    canActivate: [RoleGuard],
    data: { role: Roles.NotRegistered }
  },
  {
    path: 'errors/forbidden',
    component: ForbiddenComponent,
    canActivate: [RoleGuard],
    data: { role: Roles.NotRegistered }
  },
  // Everything else
  {
    path: '**',
    component: NotFoundComponent
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
