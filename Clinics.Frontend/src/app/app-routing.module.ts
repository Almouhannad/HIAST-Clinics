import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './usecases/shared/components/home/home.component';
import { RoleGuard } from './authentication/services/guards/role-guard';
import { Roles } from './authentication/classes/roles';
import { ForbiddenComponent } from './usecases/shared/components/errors/forbidden/forbidden.component';
import { NotFoundComponent } from './usecases/shared/components/errors/not-found/not-found.component';
import { TestSignalRComponent } from './notifications/components/test-signal-r/test-signal-r.component';
import { DoctorUsersComponent } from './usecases/admin/list-doctor-users/components/doctor-users/doctor-users.component';

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

  {
    path: 'admin/doctors',
    component: DoctorUsersComponent,
    canActivate: [RoleGuard],
    // canActivateChild: [RoleGuard],
    data: { role: Roles.Admin },
    
  },
  
  // #region Testing SignalR
  {
    path: 'testing',
    component: TestSignalRComponent,
    canActivate: [RoleGuard],
    data: { role: Roles.NotRegistered }
  },
  // #endregion
  
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
